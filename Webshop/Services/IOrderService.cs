using System.Collections.Generic;
using Webshop.Models;

namespace Webshop.Services
{
    public interface IOrderService
    {
        IList<Order> GetOrdersToUser(string userName);
    }
}