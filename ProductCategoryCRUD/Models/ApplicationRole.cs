﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductCategoryCRUD.Models
{
    public class ApplicationRole: IdentityRole
    {
        public ApplicationRole() { }
        public string Description { get; set; }
    }
}