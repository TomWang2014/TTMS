using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TTMS.Infrastructure.Runtime.Session;

namespace TTMS.Web.Portal.Toolkits
{

    /// <summary>
    ///  IAppSession的实现
    /// </summary>
    public class AppSession : IAppSession
    {
        /// <summary>
        /// 当前用户id
        /// </summary>
        public int? UserId
        {
            get
            {
                if (UserIdentity.CurrentUser != null)
                {
                    return UserIdentity.CurrentUser.Id;
                }

                return null;
            }
        }
    }
}