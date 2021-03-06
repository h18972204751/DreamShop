﻿using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 资源分类表
    /// </summary>
    public partial class UmsResourceCategory
    {
        public long Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
    }
}
