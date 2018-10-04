using System.Globalization;
using System.Threading;
using System.Web.Mvc;
using Webshop.Models.ViewModels;

namespace Webshop.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Redirect("MenuItems");
        }

        [HttpGet]
        public ActionResult ChangeLanguage(string language)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);

            Session["CurrentCulture"] = language;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}