﻿using Identity.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Model
{
    public class Logins:BaseModel
    {
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName { get; set; }

        /// <summary>
        /// md5加密的密码
        /// </summary>
        public string LoginPassword { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public UserStatus Status { get; set; }

        public DateTime CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public int UpdateUserId { get; set; }
    }
}
