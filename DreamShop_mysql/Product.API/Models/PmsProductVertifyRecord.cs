using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 商品审核记录
    /// </summary>
    public partial class PmsProductVertifyRecord
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string VertifyMan { get; set; }
        public int? Status { get; set; }

        /// <summary>
        /// 反馈详情
        /// </summary>
        public string Detail { get; set; }
    }
}
