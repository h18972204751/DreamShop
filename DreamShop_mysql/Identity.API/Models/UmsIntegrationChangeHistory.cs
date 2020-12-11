using System;
using System.Collections.Generic;

namespace Identity.API.Models
{
    /// <summary>
    /// 积分变化历史记录表
    /// </summary>
    public partial class UmsIntegrationChangeHistory
    {
        public long Id { get; set; }
        /// <summary>
        /// 会员id
        /// </summary>
        public long? MemberId { get; set; }
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 改变类型：0->增加；1->减少
        /// </summary>
        public int? ChangeType { get; set; }
        /// <summary>
        /// 积分改变数量
        /// </summary>
        public int? ChangeCount { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string OperateMan { get; set; }
        /// <summary>
        /// 操作备注
        /// </summary>
        public string OperateNote { get; set; }
        /// <summary>
        /// 积分来源：0->购物；1->管理员修改
        /// </summary>
        public int? SourceType { get; set; }
    }
}
