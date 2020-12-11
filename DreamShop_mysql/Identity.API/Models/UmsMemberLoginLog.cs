using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 会员登录记录
    /// </summary>
    public partial class UmsMemberLoginLog
    {
        public long Id { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        public long? MemberId { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Ip { get; set; }
        public string City { get; set; }

        /// <summary>
        /// 登录类型：0->PC；1->android;2->ios;3->小程序
        /// </summary>
        public int? LoginType { get; set; }
        public string Province { get; set; }
    }
}
