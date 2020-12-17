using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 产品分类
    /// </summary>
    public partial class PmsProductCategory
    {
        public long Id { get; set; }

        /// <summary>
        /// 上机分类的编号：0表示一级分类
        /// </summary>
        public long? ParentId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 分类级别：0->1级；1->2级
        /// </summary>
        public int? Level { get; set; }
        public int? ProductCount { get; set; }
        public string ProductUnit { get; set; }

        /// <summary>
        /// 是否显示在导航栏：0->不显示；1->显示
        /// </summary>
        public int? NavStatus { get; set; }

        /// <summary>
        /// 显示状态：0->不显示；1->显示
        /// </summary>
        public int? ShowStatus { get; set; }
        public int? Sort { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        public string Keywords { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
