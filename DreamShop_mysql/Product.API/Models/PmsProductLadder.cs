using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 产品阶梯价格表(只针对同商品)
    /// </summary>
    public partial class PmsProductLadder
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }

        /// <summary>
        /// 满足的商品数量
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? Discount { get; set; }

        /// <summary>
        /// 折后价格
        /// </summary>
        public decimal? Price { get; set; }
    }
}
