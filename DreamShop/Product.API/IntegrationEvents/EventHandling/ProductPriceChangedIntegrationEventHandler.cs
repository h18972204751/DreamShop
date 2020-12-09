using EventBus.Abstractions;
using Product.API.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.API.IntegrationEvents.EventHandling
{
    public class ProductPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ProductPriceChangedIntegrationEvent>
    {
        private readonly Data.ProductDbContext productDbContext;

        public ProductPriceChangedIntegrationEventHandler(Data.ProductDbContext productDbContext)
        {
            Console.WriteLine("订阅0");
            this.productDbContext = productDbContext ?? throw new ArgumentNullException(nameof(productDbContext));
        }


        public async Task Handle(ProductPriceChangedIntegrationEvent @event)
        {
            Console.WriteLine("订阅1");
            var productType = productDbContext.ProductType.AsQueryable().ToList();
            await UpdatePriceInBasketItems(@event.ProductTypeId, @event.Name, @event.Code, productType);
            Console.WriteLine("订阅1111");
        }

        private async Task UpdatePriceInBasketItems(int productId, string name, string code, List<Model.ProductType> productType)
        {
            Console.WriteLine("订阅2");
            var itemsToUpdate= productType.Where(x => x.Id == productId).FirstOrDefault();
            itemsToUpdate.Name = name;
            itemsToUpdate.Code = code;
            productDbContext.Update(itemsToUpdate);
            Console.WriteLine("订阅3");
            await productDbContext.SaveChangesAsync();
            Console.WriteLine("订阅4");
        }
    }
}
