using System;
using System.Collections.Generic;

namespace Identity.API.Models
{

    /// <summary>
    /// 后台用户角色表
    /// </summary>
    public partial class UmsRole
    {
        public long Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 后台用户数量
        /// </summary>
        public int? AdminCount { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 启用状态：0->禁用；1->启用
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
    }
}
