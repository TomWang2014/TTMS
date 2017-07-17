﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TTMS.Repository
{
    /// <summary>
    /// EntityContext
    /// </summary>
    public class AppContext : DbContext
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        /// <param name="nameOrConnectionString">连接字符串名</param>
        public AppContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}
