// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppAuthorizationException.cs" company="">
//   
// </copyright>
// <author>海淀区吴彦祖</author>
// <summary>
//   没有权限的异常
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TTMS.Infrastructure.Exceptions
{
    /// <summary>
    /// 没有权限的异常
    /// </summary>
    public class AppAuthorizationException : System.Exception
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="message">
        /// 异常消息
        /// </param>
        public AppAuthorizationException(string message)
            : base(message)
        {
        }
    }
}
