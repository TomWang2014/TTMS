﻿//------------------------------------------------------------
// <copyright file="LoginLogDto.cs" company="zjzx">
//    ©2015 信伦科技发展有限公司 版权所有
// </copyright>
// <author>海淀区吴彦祖</author>
// <date>2016/12/9 11:20:15</date>
// <summary>
//  主要功能有：
//  
// </summary>
//------------------------------------------------------------

namespace TTMS.Infrastructure.Entity
{
    using System;

    /// <summary>
    /// 登陆日志dot
    /// </summary>
    public class LoginLogDto
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string AddressId { get; set; }

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string BrowserInfo { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }
    }
}
