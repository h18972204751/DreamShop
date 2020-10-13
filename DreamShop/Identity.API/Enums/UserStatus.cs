using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Enums
{
    public enum UserStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 锁定
        /// </summary>
        Locked = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        Forbidden = 2
    }
}
