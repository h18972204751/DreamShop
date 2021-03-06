﻿using System;
using System.Collections.Generic;

namespace Product.API.Models
{

    /// <summary>
    /// sku的库存
    /// </summary>
    public partial class PmsSkuStock
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }

        /// <summary>
        /// sku编码
        /// </summary>
        public string SkuCode { get; set; }
        public decimal? Price { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int? Stock { get; set; }

        /// <summary>
        /// 预警库存
        /// </summary>
        public int? LowStock { get; set; }

        /// <summary>
        /// 展示图片
        /// </summary>
        public string Pic { get; set; }

        /// <summary>
        /// 销量
        /// </summary>
        public int? Sale { get; set; }

        /// <summary>
        /// 单品促销价格
        /// </summary>
        public decimal? PromotionPrice { get; set; }

        /// <summary>
        /// 锁定库存
        /// </summary>
        public int? LockStock { get; set; }

        /// <summary>
        /// 商品销售属性，json格式
        /// </summary>
        public string SpData { get; set; }
    }
}
