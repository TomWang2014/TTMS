using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTMS.Application.SystemMgtServices.Dtos;

namespace TTMS.Web.Portal.Toolkits
{
    public class UserIdentity
    {
        /// <summary>
        /// Gets or sets the current user.
        /// </summary>
        public static CurrentUserDto CurrentUser
        {
            get
            {
                var user = HttpContext.Current.Session["CurrentUserDto"];
                return user as CurrentUserDto;
            }

            set
            {
                HttpContext.Current.Session["CurrentUserDto"] = value;
            }
        }
    }
}