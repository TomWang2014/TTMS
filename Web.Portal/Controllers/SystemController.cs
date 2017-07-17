using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTMS.Application.SystemMgtServices;
using TTMS.Infrastructure.Mvc.Authorization;
using TTMS.Infrastructure.Mvc.ModelBinder;
using TTMS.Web.Portal.Toolkits;

namespace TTMS.Web.Portal.Controllers
{
    /// <summary>
    /// 系统管理
    /// </summary>
    public class SystemController : AppAuthorizeController
    {
        /// <summary>
        /// 系统服务
        /// </summary>
        private readonly SystemServices systemServices;



        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="systemServices">
        /// 系统服务
        /// </param>
        /// <param name="orgMgtService">机构设置</param>
        public SystemController(SystemServices systemServices)
        {
            this.systemServices = systemServices;

        }

        #region 用户管理相关



        /// <summary>
        /// 刷新session
        /// </summary>
        [AnonymousAttribute]
        public void RefreshSession()
        {
            var obj = UserIdentity.CurrentUser.Account;
        }

        #endregion
    }
}