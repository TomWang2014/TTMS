using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Application.SystemMgtServices.Dtos;
using TTMS.Domain.Systems;
using TTMS.Infrastructure.Toolkit;
using TTMS.Infrastructure.Unity.Aop;
using TTMS.Infrastructure.AutoMapper;
using TTMS.Infrastructure.Exceptions;
using TTMS.Infrastructure.Data;

namespace TTMS.Application.SystemMgtServices
{
    public class SystemServices : InterceptiveObject
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        private readonly ISysUserRepository sysUserRepository;
        /// <summary>
        /// 权限仓储
        /// </summary>
        private readonly ISysFuncRepository sysFuncRepository;

        /// <summary>
        /// 角色仓储
        /// </summary>
        private readonly ISysRoleRepository sysRoleRepository;

        /// <summary>
        /// 数据库工作单元
        /// </summary>
        private readonly IUnitOfWork unitOfWork;


        public SystemServices(ISysUserRepository _sysUserRepository, ISysFuncRepository sysFuncRepository, IUnitOfWork unitOfWork, ISysRoleRepository sysRoleRepository)
        {
            this.sysUserRepository = _sysUserRepository;
            this.sysFuncRepository = sysFuncRepository;          
            this.sysRoleRepository = sysRoleRepository;
            this.unitOfWork = unitOfWork;
        }

        #region 用户相关操作

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account">
        /// 账号 
        /// </param>
        /// <param name="password">
        /// 密码 
        /// </param>
        /// <param name="errorMsg">
        /// 消息 
        /// </param>
        /// <returns>
        /// 结果 
        /// </returns>
        public CurrentUserDto UserLogin(string account, string password, out string errorMsg)
        {
            errorMsg = string.Empty;
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(password))
            {
                errorMsg = "登录账号和密码不能为空。";
                return null;
            }

            var users = this.sysUserRepository.GetFilteredElements(a => a.Account == account && a.IsDelete == false).ToList();
            if (users.Count == 0)
            {
                errorMsg = "登录失败，不存在该用户。";
                return null;
            }

            foreach (var sysUser in users)
            {
                var md5Pwd = Hasher.GetMd5Hash(password).ToUpper();
                if (sysUser.Password.ToUpper() == md5Pwd)
                {
                    // 登录成功
                    var temp = sysUser.MapTo<CurrentUserDto>();
                    temp.FuncItems = this.GetFuncByUser(sysUser.Account);

                    // admin账号特殊处理，拥有全部权限
                    // if (sysUser.Account.ToLower() == "admin")
                    // {
                    // temp.FuncItems = this.GetAllNotTenantFuncs();
                    // }            
                    return temp;
                }
            }

            errorMsg = "登录失败，账号或者密码不匹配。";
            return null;
        }
        #endregion


        #region 权限操作相关

        /// <summary>
        /// 获得所有权限列表
        /// </summary>
        /// <returns>权限集合</returns>
        public List<SysFuncItem> GetAllSysFuncs()
        {
            var list = this.sysFuncRepository.GetAll().Where(a => a.FuncType == 1).OrderBy(a => a.OrderNumber).ToList();
            return list.MapTo<List<SysFuncItem>>();
        }

        /// <summary>
        /// 获得用户权限列表
        /// </summary>
        /// <param name="account">
        /// 用户账号
        /// </param>
        /// <returns>
        /// 返回权限 
        /// </returns>
        public List<SysFuncItem> GetFuncByUser(string account)
        {
            var list = new List<SysFuncItem>();
            var user = this.sysUserRepository.GetFilteredElements(a => a.Account == account).FirstOrDefault();

            if (user == null)
            {
                throw new UserFriendlyException(account + "账号未能查找到用户信息。");
            }

            // 用户没有任何角色
            if (user.SysRole == null)
            {
                return list;
            }

            var allFunc = user.SysRole.SysFunc.MapTo<List<SysFuncItem>>();

            // 该用户实际拥有的权限idj集合
            var allFuncIds = allFunc.Select(a => a.Id).ToList();

            // 只过滤一级菜单
            foreach (var f in allFunc.Where(a => a.FuncType == 1))
            {
                var model = f;
                var sonFuns = f.NetSysFunc1.ToList();

                model.NetSysFunc1.Clear();
                foreach (var func in sonFuns.Where(func => allFuncIds.Contains(func.Id) && func.IsDisplay == true))
                {
                    model.NetSysFunc1.Add(func);
                }

                list.Add(model);
            }

            return list;
        }

        #endregion
    }
}
