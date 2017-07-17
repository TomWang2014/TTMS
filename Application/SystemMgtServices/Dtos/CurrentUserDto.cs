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
    /// 当前登录用户
    /// </summary>
    [Serializable]
    [AutoMap(typeof(SysUser))]
    public class CurrentUserDto : EntityDto<int>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CurrentUserDto()
        {
            this.FuncItems = new List<SysFuncItem>();
            this.AuthenticationUrl = new List<string>();
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }


        /// <summary>
        /// 用户昵称
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// 认证通过的Url
        /// </summary>
        public List<string> AuthenticationUrl { get; set; }

        /// <summary>
        /// 用户权限
        /// </summary>
        public List<SysFuncItem> FuncItems { get; set; }


        /// <summary>
        /// 用户所属权限
        /// </summary>
        public RoleNote SysRole { get; set; }


        /// <summary>
        /// 获得角色名称
        /// </summary>
        /// <returns>角色名称</returns>
        public override string ToString()
        {
            return this.SysRole == null ? string.Empty : this.SysRole.Name;
        }



    }
}
