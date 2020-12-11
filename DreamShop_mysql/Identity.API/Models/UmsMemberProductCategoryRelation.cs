using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 会员与产品分类关系表（用户喜欢的分类）
    /// </summary>
    public partial class UmsMemberProductCategoryRelation
    {
        public long Id { get; set; }

        /// <summary>
        /// 会员
        /// </summary>
        public long? MemberId { get; set; }

        /// <summary>
        /// 用户喜欢得分类
        /// </summary>
        public long? ProductCategoryId { get; set; }
    }
}
