using EventBus.Abstractions;
using Orders.API.Infrastructure.IRepository;
using Orders.API.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.IntegrationEvents.EventHandling
{
    public class ProductPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ProductPriceChangedIntegrationEvent>
    {
        private readonly Data.OrdersDbContext  ordersDbContext;

        public ProductPriceChangedIntegrationEventHandler(Data.OrdersDbContext ordersDbContext)
        {
           this.ordersDbContext = ordersDbContext ?? throw new ArgumentNullException(nameof(ordersDbContext));
        }


        public async Task Handle(ProductPriceChangedIntegrationEvent @event)
        {
            Console.WriteLine("订阅1");
            //var productType = ordersDbContext.ProductType.AsQueryable().ToList();
            //await UpdatePriceInBasketItems(@event.ProductTypeId, @event.Name, @event.Code, productType);
            Console.WriteLine("订阅1111");
        }

        private async Task UpdatePriceInBasketItems(int productId, string name, string code, List<Model.Orders> productType)
        {
            Console.WriteLine("订阅2");
            //var itemsToUpdate = productType.Where(x => x.Id == productId).FirstOrDefault();
            //itemsToUpdate.Name = name;
            //itemsToUpdate.Code = code;
            //productDbContext.Update(itemsToUpdate);
            //Console.WriteLine("订阅3");
            //await productDbContext.SaveChangesAsync();
            Console.WriteLine("订阅4");
        }
    }
}
