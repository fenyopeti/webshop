using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
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

            container.RegisterType<IMenuItemService, MenuItemService>();
            container.RegisterType<ICategoriesService, CategoriesService>();
            container.RegisterType<ICartService, CartService>();

            return container;
        }
    }
}