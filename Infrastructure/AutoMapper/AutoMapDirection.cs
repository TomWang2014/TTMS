// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapDirection.cs" company="">
//   
// </copyright>
// <author>海淀区吴彦祖</author>
// <summary>
//   AutoMap方向的枚举
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TTMS.Infrastructure.AutoMapper
{
    using System;

    /// <summary>
    /// AutoMap方向的枚举
    /// </summary>
    [Flags]
    public enum AutoMapDirection
    {
        /// <summary>
        /// 从目标类型映射而来
        /// </summary>
        From, 

        /// <summary>
        /// 向目标类型映射而去
        /// </summary>
        To
    }
}