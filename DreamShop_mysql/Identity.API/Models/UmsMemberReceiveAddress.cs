using System;
using System.Collections.Generic;

namespace Identity.API.Models
{

    /// <summary>
    /// 会员收货地址表
    /// </summary>
    public partial class UmsMemberReceiveAddress
    {
        public long Id { get; set; }
        
        /// <summary>
        /// 会员id
        /// </summary>
        public long? MemberId { get; set; }

        /// <summary>
        /// 收货人名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 是否为默认
        /// </summary>
        public int? DefaultStatus { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 省份/直辖市
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// 详细地址(街道)
        /// </summary>
        public string DetailAddress { get; set; }
    }
}
