namespace TTMS.Repository.Systems
{
    using TTMS.Domain;
    using TTMS.Domain.Systems;
    using TTMS.Infrastructure.Data;

    /// <summary>
    /// ResDataCategoryRepository
    /// </summary>
    public class SysFuncRepository : RepositoryBase<SysFunc>, ISysFuncRepository
    {
        /// <summary>
        /// 够着函数
        /// </summary>
        /// <param name="context">数据库上下文</param>
        public SysFuncRepository(AppContext context)
            : base(context)
        {
        }
    }
}
