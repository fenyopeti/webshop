using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Webshop.Auth;
using Webshop.Controllers;
using Webshop.Models;
using Webshop.Services;

namespace Webshop
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, WebshopDatabaseEntities>();
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<IUserStore<ApplicationUser, string>, UserStore<ApplicationUser>>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<ApplicationSignInManager>();

            container.RegisterType<IMenuItemService, MenuItemService>();
            container.RegisterType<ICategoriesService, CategoriesService>();
            container.RegisterType<ICartService, CartService>();
            container.RegisterType<IOrderService, OrderService>();

            return container;
        }
    }
}