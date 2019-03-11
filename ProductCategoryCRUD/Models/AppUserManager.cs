using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCategoryCRUD.Models
{
    public class AppUserManager : UserManager<ApplicationUser>
    {
        public AppUserManager (IUserStore<ApplicationUser> userStore) : base(userStore) { }
        public static AppUserManager Create (IdentityFactoryOptions<AppUserManager> factoryOptions, IOwinContext owinContext)
        {
            ShopContext shopContext = owinContext.Get<ShopContext>();
            AppUserManager userManager = new AppUserManager(new UserStore<ApplicationUser>(shopContext));
            return userManager;
        }
    }
}