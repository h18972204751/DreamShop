using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Model
{
    public class Orders:BaseModel
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string Serial { get; set; }

        /// <summary>
        /// 下单用户id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 收货人姓名
        /// </summary>
        public string ConsigneeName { get; set; }

        /// <summary>
        /// '支付方式：1现金，2余额，3网银，4支付宝，5微信',
        /// </summary>
        public int Payment { get; set; }

        /// <summary>
        /// 原价订单总金额
        /// </summary>
        public decimal OriginalPriceSum { get; set; }

        /// <summary>
        /// 现价订单总金额
        /// </summary>
        public decimal NowPriceSum { get; set; }


        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime ShippingTime { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime PayTime { get; set; }

        /// <summary>
        /// 收货时间
        /// </summary>
        public DateTime ReceiveTime { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public DateTime OrderStatus { get; set; }


        /// <summary>
        /// 创建时间(下单时间)
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public string UpdateUserId { get; set; }

        public ICollection<OrdersInfo> OrdersInfo { get; set; }



    }
}
