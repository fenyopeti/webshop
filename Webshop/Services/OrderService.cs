using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Webshop.Models;

namespace Webshop.Services
{
    public class OrderService : IOrderService
    {
        private readonly WebshopDatabaseEntities db = new WebshopDatabaseEntities();

        public IList<Order> GetOrdersToUser(string userName)
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == userName);
            return db.Orders
                .Include(o => o.User)
                .Include(o => o.OrdersItems)
                .Where(o => o.UserId == user.Id)
                .ToList();
        }
    }
}