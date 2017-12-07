namespace OnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineShop.Model.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineShop.Data.OnlineShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineShop.Data.OnlineShopDBContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new OnlineShopDBContext()));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new OnlineShopDBContext()));

            var user = new ApplicationUser()
            {
                UserName = "Tedu",
                Email = "tedu@gmail.com",
                EmailConfirmed = true,
                Birthday = DateTime.Now,
                FullName="Technology Education"
            };

            manager.Create(user, "123456$");

            if(!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole() { Name = "Admin" });
                roleManager.Create(new IdentityRole() { Name = "User" });
            }

            var adminUser = manager.FindByEmail("tedu@gmail.com");

            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }
    }
}
