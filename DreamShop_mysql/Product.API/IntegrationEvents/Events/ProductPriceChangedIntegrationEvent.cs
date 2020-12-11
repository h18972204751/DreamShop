using EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.IntegrationEvents.Events
{
    public class ProductPriceChangedIntegrationEvent: IntegrationEvent
    {
        //id
        public string ProductTypeId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        public ProductPriceChangedIntegrationEvent(string productTypeId, string name, string code)
        {
            ProductTypeId = productTypeId;
            Name = name;
            Code = code;
        }
    }
}
