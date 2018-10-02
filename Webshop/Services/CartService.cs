using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webshop.Models;

namespace Webshop.Services
{
    public class CartService : ICartService
    {
        private readonly WebshopDatabaseEntities db = new WebshopDatabaseEntities();
        private readonly string CartSessionKey = "CartId";

        public IList<CartItem> GetCartItems()
        {
            var cartId = getCartId();

            return db.CartItems
                .Where(c => c.CartId == cartId)
                .ToList();
        }

        public void AddToCart(Guid menuItemId)
        {
            var cartId = getCartId();

            var cartItem = db.CartItems
                .Where(c => c.CartId == cartId)
                .Where(c => c.MenuItemId == menuItemId)
                .FirstOrDefault();

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    MenuItemId = menuItemId,
                    CartId = cartId,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                db.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
            }
            db.SaveChanges();
        }

        public void Checkout(string userName)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == userName);
            var order = new Order
            {
                id = Guid.NewGuid(),
                Date = DateTime.Now,
                amount = GetCartPrice(),
                User = user
            };
            db.Orders.Add(order);
            db.SaveChanges();

            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                var orderItem = new OrdersItem
                {
                    Id = Guid.NewGuid(),
                    MenuItemId = item.MenuItemId,
                    OrderId = order.id,
                    Quantity = item.Quantity
                };

                db.OrdersItems.Add(orderItem);
                db.SaveChanges();

                var menuItem = db.MenuItems.Find(item.MenuItem.Id);
                if (menuItem.OrderedSum == null)
                {
                    menuItem.OrderedSum = item.Quantity;
                }
                else
                {
                    menuItem.OrderedSum += item.Quantity;
                }
            }
            db.SaveChanges();
        }

        public int GetCartPrice()
        {
            var amount = 0;
            var cartItems = GetCartItems();
            foreach (var item in cartItems)
            {
                amount += (int)item.MenuItem.Price * (int)item.Quantity;
            }

            return amount;
        }

        public void DeleteCart()
        {
            foreach (var item in GetCartItems())
            {
                db.CartItems.Remove(item);
            }
            db.SaveChanges();

            HttpContext.Current.Session[CartSessionKey] = null;
        }

        public bool CanAddToCart(Guid menuItemId)
        {
            var amount = GetCartPrice();
            var menuitem = db.MenuItems.Find(menuItemId);

            return (amount + menuitem.Price < 20000);
        }

        public void DeleteFromCart(Guid menuItemId)
        {
            var cartId = getCartId();

            var cartItem = db.CartItems
                .Where(c => c.CartId == cartId)
                .Where(c => c.MenuItemId == menuItemId)
                .FirstOrDefault();

            db.CartItems.Remove(cartItem);
            db.SaveChanges();
        }

        private string getCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
