using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Model
{
    public class OrdersInfo:BaseModel
    {
        /// <summary>
        /// 订单id
        /// </summary>
        public string OrdersId { get; set; }
        /// <summary>
        /// 商品id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int ProductNum { get; set; }

        /// <summary>
        /// 原价
        /// </summary>
        public decimal OriginalPrice { get; set; }
        /// <summary>
        /// 现价
        /// </summary>
        public decimal NowPrice { get; set; }


        public DateTime CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime? UpdateTime { get; set; } = DateTime.Now;
        public int? UpdateUserId { get; set; }

        public Orders Orders { get; set; }
    }
}
