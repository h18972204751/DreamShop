using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 后台用户登录日志表
    /// </summary>
    public partial class UmsAdminLoginLog
    {
        public long Id { get; set; }
        /// <summary>
        /// 后台用户Id
        /// </summary>
        public long? AdminId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Ip { get; set; }
        public string Address { get; set; }
        /// <summary>
        /// 浏览器登录类型
        /// </summary>
        public string UserAgent { get; set; }
    }
}
