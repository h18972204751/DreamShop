using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 产品的分类和属性的关系表，用于设置分类筛选条件（只支持一级分类）
    /// </summary>
    public partial class PmsProductCategoryAttributeRelation
    {
        public long Id { get; set; }
        public long? ProductCategoryId { get; set; }
        public long? ProductAttributeId { get; set; }
    }
}
