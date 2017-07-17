using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TTMS.Infrastructure.Mvc.Filter;

namespace TTMS.Web.Portal.Toolkits
{
    /// <summary>
    /// 需要权限的控制器基类
    /// </summary>
    [Exception(View = "Error")]
    [AppAuthorize]
    public class AppAuthorizeController : Controller
    {
    }
}