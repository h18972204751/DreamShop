using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 用户和标签关系表
    /// </summary>
    public partial class UmsMemberMemberTagRelation
    {
        public long Id { get; set; }
        public long? MemberId { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public long? TagId { get; set; }
    }
}
