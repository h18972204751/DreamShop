using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 产品属性分类表
    /// </summary>
    public partial class PmsProductAttributeCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 属性数量
        /// </summary>
        public int? AttributeCount { get; set; }

        /// <summary>
        /// 参数数量
        /// </summary>
        public int? ParamCount { get; set; }
    }
}
