using System.Web.Mvc;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AccountController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult History()
        {
            var orders = _orderService.GetOrdersToUser(User.Identity.Name);

            return View(orders);
        }
    }
}