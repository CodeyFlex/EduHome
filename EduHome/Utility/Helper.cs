using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Utility
{
    public static class Helper
    {
        public static string User = "User";
        public static string Admin = "Admin";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=Helper.User, Text=Helper.User},
                new SelectListItem{Value=Helper.Admin, Text=Helper.Admin}
            };
        }
    }
}
