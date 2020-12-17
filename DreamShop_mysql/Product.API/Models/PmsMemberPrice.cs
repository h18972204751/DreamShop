using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 商品会员价格表
    /// </summary>
    public partial class PmsMemberPrice
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? MemberLevelId { get; set; }

        /// <summary>
        /// 会员价格
        /// </summary>
        public decimal? MemberPrice { get; set; }
        public string MemberLevelName { get; set; }
    }
}
