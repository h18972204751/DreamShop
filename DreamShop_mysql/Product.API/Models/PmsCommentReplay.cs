using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// 产品评价回复表
    /// </summary>
    public partial class PmsCommentReplay
    {
        public long Id { get; set; }
        public long? CommentId { get; set; }
        public string MemberNickName { get; set; }
        public string MemberIcon { get; set; }
        public string Content { get; set; }
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 评论人员类型；0->会员；1->管理员
        /// </summary>
        public int? Type { get; set; }
    }
}
