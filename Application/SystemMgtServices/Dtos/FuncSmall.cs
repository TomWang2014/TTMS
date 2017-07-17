using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain;
using TTMS.Infrastructure.AutoMapper;
using TTMS.Infrastructure.Toolkit;

namespace TTMS.Application.SystemMgtServices.Dtos
{
    /// <summary>
    /// The func small.
    /// </summary>
    [Serializable]
    [AutoMap(typeof(SysFunc))]
    public class FuncSmall
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 区域
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 访问Action名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 访问Controller名称
        /// </summary>
        public string ControllerName { get; set; }


        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 获得完整路径
        /// </summary>
        /// <returns>返回url</returns>
        public override string ToString()
        {
            return StringUrlExtension.GetRequestUrlByParameter(this.AreaName, this.ControllerName, this.ActionName);
        }

        public bool IsDisplay { get; set; }
    }
}
