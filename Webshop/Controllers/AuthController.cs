using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Webshop.Auth;
using Webshop.Models;
using Webshop.Models.ViewModels;

namespace Webshop.Controllers
{
    [Authorize]
    public class AuthController : ControllerBase
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public AuthController()
        {

        }

        public AuthController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = _userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAsync(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            switch (result)
            {
                case SignInStatus.Success:
                    return Redirect("/");
                default:
                    ModelState.AddModelError("", Resources.ModelValidation.InvalidLogin);
                    return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RegisterAsync(RegisterViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = new ApplicationUser()
            {
                UserName = userModel.Email,
                Email = userModel.Email,
                Name = userModel.Name,
                Address = userModel.Address,
                PhoneNumber = userModel.Phone
            };

            var result = await UserManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, result.Errors.FirstOrDefault());
            }

            await SignInManager.SignInAsync(user, false, false);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
    }
}