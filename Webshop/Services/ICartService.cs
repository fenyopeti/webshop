using System;
using System.Collections.Generic;
using Webshop.Models;

namespace Webshop.Services
{
    public interface ICartService : IDisposable
    {
        void AddToCart(Guid menuItemId);
        IList<CartItem> GetCartItems();
        void Checkout(string userName);
        bool CanAddToCart(Guid menuItemId);
        void DeleteCart();
        int GetCartPrice();
        void DeleteFromCart(Guid id);
    }
}