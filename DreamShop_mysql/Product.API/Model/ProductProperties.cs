using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.Model
{
    public class ProductProperties:BaseModel
    {
        /// <summary>
        /// 属性值(名字：颜色)
        /// </summary>
        public string Title { set; get; }
        /// <summary>
        /// 唯一编号
        /// </summary>
        public string PropertiesGuid { set; get; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 对应产品的唯一编号
        /// </summary>
        public string ProductID { set; get; }

        public Products Products { get; set; }
    }
}
