using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventBus.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Product.API.IntegrationEvents.EventHandling;
using Product.API.IntegrationEvents.Events;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEventBus _eventBus;

        public ProductsController(ILogger<ProductsController> logger, IConfiguration configuration, IEventBus eventBus)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._eventBus = eventBus;
        }

        //[Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            //_eventBus.Subscribe<ProductPriceChangedIntegrationEvent, ProductPriceChangedIntegrationEventHandler>();
            Console.WriteLine("123");
            string result = $"【产品服务】{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}——" +
                $"{Request.HttpContext.Connection.LocalIpAddress}:{_configuration["ConsulSetting:ServicePort"]}";
            return Ok(result);
        }


    }
}
