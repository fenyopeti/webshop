using System.Web.Mvc;

namespace Webshop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Redirect("MenuItems");
        }
    }
}