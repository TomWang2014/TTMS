using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TTMS.Application;
using TTMS.Infrastructure.Mvc;
using TTMS.Infrastructure.Unity.Ioc;
using TTMS.Infrastructure.Toolkit;
using TTMS.Web.Portal.Toolkits;

namespace Web.Portal
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // 实现自定义的依赖注入控制器
            var container = IocManager.Instance.GetContainer();
            var factory = new UnityControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(factory);

            // 运行应用程序初始化操作
            AppInit.Run();
            ToolkitsHelper.InitAllFunc();

            // 启用EF性能调试工具
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
        }
    }
}
