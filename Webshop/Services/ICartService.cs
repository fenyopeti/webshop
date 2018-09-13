using System;
using System.Collections.Generic;
using Webshop.Models;
using Webshop.Models.DTOs;

namespace Webshop.Services
{
    public interface ICartService : IDisposable
    {
        void AddToCart(Guid menuItemId);
        IList<CartItem> GetCartItems();
        void Checkout(UserInfoDTO userInfo);
        bool CanAddToCart(Guid menuItemId);
        void DeleteCart();
        int GetCartPrice();
        void DeleteFromCart(Guid id);
    }
}