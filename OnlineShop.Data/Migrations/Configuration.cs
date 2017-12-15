﻿namespace OnlineShop.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using OnlineShop.Model.Models;
    using System;
    using System.Collections.Generic;
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
            CreateProductCategorySample(context);
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new OnlineShopDBContext()));

            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new OnlineShopDBContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "Tedu",
            //    Email = "tedu@gmail.com",
            //    EmailConfirmed = true,
            //    Birthday = DateTime.Now,
            //    FullName="Technology Education"
            //};

            //manager.Create(user, "123456$");

            //if(!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole() { Name = "Admin" });
            //    roleManager.Create(new IdentityRole() { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("tedu@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(OnlineShop.Data.OnlineShopDBContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> productCategory = new List<ProductCategory>()
            {
                new ProductCategory(){Name="Điện lạnh", Alias="dien-lanh", Status=true},
                new ProductCategory(){Name="Viễn thông", Alias="vien-thongg", Status=true},
                new ProductCategory(){Name="Đồ gia dụng", Alias="do-gia-dungg", Status=true},
                new ProductCategory(){Name="Mỹ phẩm", Alias="my-pham", Status=true}
            };

                context.ProductCategories.AddRange(productCategory);
                context.SaveChanges();
            }
        }
    }
}
