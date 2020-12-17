using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 运费模版
    /// </summary>
    public partial class PmsFeightTemplate
    {
        public long Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 计费类型:0->按重量；1->按件数
        /// </summary>
        public int? ChargeType { get; set; }

        /// <summary>
        /// 首重kg
        /// </summary>
        public decimal? FirstWeight { get; set; }

        /// <summary>
        /// 首费（元）
        /// </summary>
        public decimal? FirstFee { get; set; }
        public decimal? ContinueWeight { get; set; }
        public decimal? ContinmeFee { get; set; }

        /// <summary>
        /// 目的地（省、市）
        /// </summary>
        public string Dest { get; set; }
    }
}
