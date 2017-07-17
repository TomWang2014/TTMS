using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTMS.Web.Portal.Models
{
    /// <summary>
    /// 访问权限模型
    /// </summary>
    public class AuthorityUrls
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AuthorityUrls()
        {
            this.IncludeUrl = new List<string>();
        }

        /// <summary>
        /// 权限
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 权限对应的访问url
        /// </summary>
        public List<string> IncludeUrl { get; set; }
    }
}