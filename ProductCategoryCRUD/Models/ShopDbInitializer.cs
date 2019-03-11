using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductCategoryCRUD.Models
{
    public class ShopDbInitializer : DropCreateDatabaseAlways<ShopContext>
    {
        protected override void Seed(ShopContext context)
        {
            context.Products.Add(new Product { Name = "Pepsi", Price = 12.80, CategoryId = 1 });
            context.Products.Add(new Product { Name = "Sandora", Price = 19.80, CategoryId = 3 });
            context.Products.Add(new Product { Name = "Mirinda", Price = 12.80, CategoryId = 1 });
            context.Products.Add(new Product { Name = "Lay's", Price = 16.50, CategoryId = 2 });
            context.Products.Add(new Product { Name = "7up", Price = 12.80, CategoryId = 1 });

            context.Categories.Add(new Category { Name = "Beverage" });
            context.Categories.Add(new Category { Name = "Snack" });
            context.Categories.Add(new Category { Name = "Juice" });

            var userManager = new AppUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
            roleManager.Create(role1);
            roleManager.Create(role2);

            var admin = new ApplicationUser { Email = "admin@gmail.com", UserName = "Admin" };
            string password = "administrator";
            var result = userManager.Create(admin, password);
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role1.Name);
            }

            base.Seed(context);

        }
    }
}