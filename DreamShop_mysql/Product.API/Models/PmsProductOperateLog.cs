using System;
using System.Collections.Generic;

namespace Product.API.Models
{
    public partial class PmsProductOperateLog
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public decimal? PriceOld { get; set; }
        public decimal? PriceNew { get; set; }
        public decimal? SalePriceOld { get; set; }
        public decimal? SalePriceNew { get; set; }

        /// <summary>
        /// 赠送的积分
        /// </summary>
        public int? GiftPointOld { get; set; }
        public int? GiftPointNew { get; set; }
        public int? UsePointLimitOld { get; set; }
        public int? UsePointLimitNew { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        public string OperateMan { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
