using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 产品满减表(只针对同商品)
    /// </summary>
    public partial class PmsProductFullReduction
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public decimal? FullPrice { get; set; }
        public decimal? ReducePrice { get; set; }
    }
}
