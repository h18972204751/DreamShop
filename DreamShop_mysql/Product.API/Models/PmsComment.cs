using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 商品评价表
    /// </summary>
    public partial class PmsComment
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public string MemberNickName { get; set; }
        public string ProductName { get; set; }

        /// <summary>
        /// 评价星数：0->5
        /// </summary>
        public int? Star { get; set; }

        /// <summary>
        /// 评价的ip
        /// </summary>
        public string MemberIp { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? ShowStatus { get; set; }

        /// <summary>
        /// 购买时的商品属性
        /// </summary>
        public string ProductAttribute { get; set; }
        public int? CollectCouont { get; set; }
        public int? ReadCount { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// 上传图片地址，以逗号隔开
        /// </summary>
        public string Pics { get; set; }

        /// <summary>
        /// 评论用户头像
        /// </summary>
        public string MemberIcon { get; set; }
        public int? ReplayCount { get; set; }
    }
}
