using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTMS.Web.Portal.Toolkits
{
    /// <summary>
    /// 域控制器特性类
    /// </summary>
    public class AreasAttribute : Attribute
    {
        /// <summary>
        /// 区域名称
        /// </summary>
        public string AreaName { get; set; }
    }
}