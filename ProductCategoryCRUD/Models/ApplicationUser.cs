using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCategoryCRUD.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
    }
}