using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 存储产品参数信息的表
    /// </summary>
    public partial class PmsProductAttributeValue
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? ProductAttributeId { get; set; }

        /// <summary>
        /// 手动添加规格或参数的值，参数单值，规格有多个时以逗号隔开
        /// </summary>
        public string Value { get; set; }
    }
}
