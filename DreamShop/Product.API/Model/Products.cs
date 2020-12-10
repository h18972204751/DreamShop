using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Model
{
    public class Products:BaseModel
    {

        /// <summary>
        /// 类型Id
        /// </summary>
        public int ProductTypeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Core { get; set; }


        /// <summary>
        /// 产品展示的图片集合
        /// </summary>
        public string Pic { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 已销售的数量[真实的]
        /// </summary>
        public int SellNum { set; get; }

        /// <summary>
        /// 原价
        /// </summary>
        public decimal OriginalPrice { get; set; }
        /// <summary>
        /// 现价
        /// </summary>
        public decimal NowPrice { get; set; }

        /// <summary>
        /// 开始销售的时间
        /// </summary>
        //[JsonConverter(typeof(Having.Site.Base.comm.DateTimeConverter))]
        public DateTime SellTime { set; get; }

        /// <summary>
        /// 产品是否在线（true:表示产品可以被搜索，但购买受销售时间影响;false:表示产品下架，不能搜索和购买）
        /// </summary>
        public bool Online { set; get; }

        /// <summary>
        /// 是否置顶显示
        /// </summary>
        public bool IsTop { set; get; }

        /// <summary>
        /// 置顶的时间
        /// </summary>
        [JsonIgnore]
        public DateTime TopTime { set; get; }

        /// <summary>
        /// 是否标志为新品
        /// </summary>
        public bool IsNew { set; get; }

        /// <summary>
        /// 标志新品标志从销售时间开始多少天内有效，默认1天
        /// </summary>
        public short SetNewDays { set; get; }

        /// <summary>
        /// 是否审核通过（0表示未审核，1表示审核通过，2表示不通过）
        /// </summary>
        public short IsCheck { set; get; }

        /// <summary>
        /// 商品单件重量
        /// </summary>
        public decimal Weight { set; get; }

        /// <summary>
        /// 添加的时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 销售限制｛isLimit:true,Total:10,Per:1｝isLimit:是否限制，Total：每人最多买多少，Per：单次买多少
        /// </summary>
        public string SellLimit { set; get; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Descript { get; set; }

        /// <summary>
        /// 上架状态 0未上架 1上架中 2下架中
        /// </summary>
        public int PublishStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public int CreateUserId { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public int UpdateUserId { get; set; }

        public ProductType ProductType { get; set; }

        public ICollection<ProductProperties> ProductProperties { get; set; }
    }
}
