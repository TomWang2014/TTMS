using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTMS.Domain;
using TTMS.Domain.Systems;
using TTMS.Infrastructure.Data;

namespace TTMS.Repository.Systems
{
    public class SysUserRepository : RepositoryBase<SysUser>, ISysUserRepository
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public SysUserRepository(AppContext context)
            : base(context)
        {
        }
    }
}
