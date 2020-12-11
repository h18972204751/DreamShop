using System;
using System.Collections.Generic;

namespace Identity.API.Models
{

    /// <summary>
    /// 会员统计信息
    /// </summary>
    public partial class UmsMemberStatisticsInfo
    {
        public long Id { get; set; }
        public long? MemberId { get; set; }

        /// <summary>
        /// 累计消费金额
        /// </summary>
        public decimal? ConsumeAmount { get; set; }

        /// <summary>
        /// 订单数量
        /// </summary>
        public int? OrderCount { get; set; }

        /// <summary>
        /// 优惠券数量
        /// </summary>
        public int? CouponCount { get; set; }

        /// <summary>
        /// 评价数
        /// </summary>
        public int? CommentCount { get; set; }

        /// <summary>
        /// 退货数量
        /// </summary>
        public int? ReturnOrderCount { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public int? LoginCount { get; set; }

        /// <summary>
        /// 关注数量
        /// </summary>
        public int? AttendCount { get; set; }

        /// <summary>
        /// 粉丝数量
        /// </summary>
        public int? FansCount { get; set; }

       
        public int? CollectProductCount { get; set; }
        public int? CollectSubjectCount { get; set; }
        public int? CollectTopicCount { get; set; }
        public int? CollectCommentCount { get; set; }
        public int? InviteFriendCount { get; set; }

        /// <summary>
        /// 最后一次下订单时间
        /// </summary>
        public DateTime? RecentOrderTime { get; set; }
    }
}
