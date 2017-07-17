using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain;
using TTMS.Infrastructure.AutoMapper;
using TTMS.Infrastructure.Dto;

namespace TTMS.Application.SystemMgtServices.Dtos
{
    /// <summary>
    /// RoleNote
    /// </summary>
    [Serializable]
    [AutoMap(typeof(SysRole))]
    public class RoleNote : EntityDto
    {
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
    }
}
