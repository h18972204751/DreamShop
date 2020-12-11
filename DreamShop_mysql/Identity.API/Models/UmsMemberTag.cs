using System;
using System.Collections.Generic;

namespace Identity.API.Models
{

    /// <summary>
    /// 用户标签表
    /// </summary>
    public partial class UmsMemberTag
    {
        public long Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// 自动打标签完成订单数量
        /// </summary>
        public int? FinishOrderCount { get; set; }

        /// <summary>
        /// 自动打标签完成订单金额
        /// </summary>
        public decimal? FinishOrderAmount { get; set; }
    }
}
