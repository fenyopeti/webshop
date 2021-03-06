﻿using System;
using System.Net;
using System.Web.Mvc;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Amount = _cartService.GetCartPrice();

            return View(_cartService.GetCartItems());
        }

        [HttpGet]
        public ActionResult Add(Guid id)
        {
            if (!_cartService.CanAddToCart(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _cartService.AddToCart(id);
            return RedirectToAction("Index");
        }

        [HttpGet, ActionName("DeleteFromCart")]
        public ActionResult Delete(Guid id)
        {
            _cartService.DeleteFromCart(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CheckOut()
        {
            return View();
        }

        [HttpPost, ActionName("Checkout")]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOutConfirmed()
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _cartService.Checkout(User.Identity.Name);
            _cartService.DeleteCart();
            return Redirect("/MenuItems");
        }

        [HttpGet]
        public ActionResult Delete()
        {
            _cartService.DeleteCart();
            return Redirect("/MenuItems");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}