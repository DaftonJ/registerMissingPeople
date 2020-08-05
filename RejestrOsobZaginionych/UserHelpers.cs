﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using RejestrOsobZaginionych.Enums;
using RejestrOsobZaginionych.Models;
using System;
using System.Security.Principal;
using System.Web;

namespace RejestrOsobZaginionych
{
    public static class UserHelpers
    {

        public static bool HasPermissions(this IPrincipal applicationUser, Roles roleNeeded)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = userManager.FindByName(applicationUser.Identity.Name);
            if(user == null)
            {
                return false;
            }

            return user.Role >= roleNeeded;

        }
        public static bool HasPermissions(this ApplicationUser applicationUser, Roles roleNeeded) => applicationUser.Role >= roleNeeded;
    }
}