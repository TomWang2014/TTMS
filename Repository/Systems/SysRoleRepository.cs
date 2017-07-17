namespace TTMS.Repository.Systems
{
    using TTMS.Domain;
    using TTMS.Domain.Systems;
    using TTMS.Infrastructure.Data;

    /// <summary>
    /// 角色管理仓储
    /// </summary>
    public class SysRoleRepository : RepositoryBase<SysRole>, ISysRoleRepository
    {
        /// <summary>
        /// 够着函数
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public SysRoleRepository(AppContext context)
            : base(context)
        {
        }
    }
}
