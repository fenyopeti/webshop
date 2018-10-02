namespace Webshop.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Webshop.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebshopDatabaseEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebshopDatabaseEntities context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (context.Roles.FirstOrDefault(r => r.Name == "Admin") == null)
            {
                var adminRole = new IdentityRole { Name = "Admin" };
                roleManager.Create(adminRole);
            }

            if (context.Roles.FirstOrDefault(r => r.Name == "User") == null)
            {
                var userRole = new IdentityRole { Name = "User" };
                roleManager.Create(userRole);
            }

            var adminEmail = "admin@admin.com";
            if (userManager.FindByName(adminEmail) == null)
            {
                var adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };

                userManager.Create(adminUser, "Temp_123");
                userManager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}
