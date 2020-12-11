using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 后台用户表
    /// </summary>
    public partial class UmsAdmin
    {
        public long Id { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Note { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LoginTime { get; set; }
        /// <summary>
        /// 帐号启用状态：0->禁用；1->启用
        /// </summary>
        public int? Status { get; set; }
    }
}
