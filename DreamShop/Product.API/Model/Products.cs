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
        /// 原价
        /// </summary>
        public decimal OriginalPrice { get; set; }
        /// <summary>
        /// 现价
        /// </summary>
        public decimal NowPrice { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// 库存
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// 锁定的库存
        /// </summary>
        public int LockStock { get; set; }

        /// <summary>
        /// 安全库存
        /// </summary>
        public int SafeStock { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight { get; set; }

        /// <summary>
        /// 长
        /// </summary>
        public decimal Length { get; set; }

        /// <summary>
        /// 宽
        /// </summary>
        public decimal Width { get; set; }
        /// <summary>
        /// 高
        /// </summary>
        public decimal Height { get; set; }
        
        /// <summary>
        /// 生产日期
        /// </summary>
        public DateTime ProductionDate { get; set; }
        /// <summary>
        /// 有效期
        /// </summary>
        public int ShelfLife { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Descript { get; set; }
        /// <summary>
        /// 上架状态
        /// </summary>
        public int PublishStatus { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        public string CreateUserId { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.Now;
        public string UpdateUserId { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int AuditStatus { get; set; }

        

        public ProductType ProductType { get; set; }

    }
}
