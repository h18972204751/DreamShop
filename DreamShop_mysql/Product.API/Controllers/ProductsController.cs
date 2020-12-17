//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CommonHelp;
//using EventBus.Abstractions;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Logging;
//using Product.API.Data;
//using Product.API.IntegrationEvents.EventHandling;
//using Product.API.IntegrationEvents.Events;
//using Product.API.Model;

//namespace Product.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]

//    public class ProductsController : ControllerBase
//    {
//        private readonly ILogger<ProductsController> _logger;
//        private readonly IConfiguration _configuration;
//        private readonly IEventBus _eventBus;
//        private readonly ProductDbContext _context;
//        public ProductsController(ILogger<ProductsController> logger, IConfiguration configuration, IEventBus eventBus, ProductDbContext context)
//        {
//            this._logger = logger;
//            this._configuration = configuration;
//            this._eventBus = eventBus;
//            this._context = context;
//        }

//        //[Authorize]
//        //[HttpGet]
//        //public IActionResult Get()
//        //{
//        //    //_eventBus.Subscribe<ProductPriceChangedIntegrationEvent, ProductPriceChangedIntegrationEventHandler>();
//        //    Console.WriteLine("123");
//        //    string result = $"【产品服务】{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}——" +
//        //        $"{Request.HttpContext.Connection.LocalIpAddress}:{_configuration["ConsulSetting:ServicePort"]}";
//        //    return Ok(result);
//        //}



//        [HttpGet]
//        public async Task<MessageModel<List<Products>>> Get()
//        {
//            var products = _context.Products.AsQueryable().ToList();
//            return new MessageModel<List<Products>>() { Msg = "成功!", Success = true, Response = products };
//        }

//        /// <summary>
//        /// 查询ID=id类型的所有商品
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        [HttpGet("id")]
//        public async Task<MessageModel<List<Products>>> Get(string id)
//        {
//            var products = _context.Products.AsQueryable().Where(o => o.ProductTypeId == id).ToList();
//            return new MessageModel<List<Products>>() { Msg = "成功!", Success = true, Response = products };
//        }


//        /// <summary>
//        /// 添加
//        /// </summary>
//        /// <param name="Products"></param>
//        /// <returns></returns>
//        [HttpPost]
//        [Authorize]
//        public async Task<MessageModel<Products>> Post([FromForm] Products products)
//        {
//            var productsModel = await _context.Products.AddAsync(products);
//            return new MessageModel<Products>() { Msg = "成功!", Success = true, Response = productsModel.Entity };
//        }

//        /// <summary>
//        /// 修改
//        /// </summary>
//        /// <returns></returns>
//        [HttpPut]
//        [Authorize]
//        public async Task<MessageModel<Products>> Put([FromForm] Products products)
//        {
//            var productTypeModel = _context.Products.Update(products);
//            int i = await _context.SaveChangesAsync();
//            if (i > 0)
//                return new MessageModel<Products>() { Msg = "成功!", Success = false, Response = productTypeModel.Entity };
//            else
//                return new MessageModel<Products>() { Msg = "失败!", Success = true, Response = productTypeModel.Entity };
//        }

//        /// <summary>
//        /// 删除
//        /// </summary>
//        /// <returns></returns>
//        [HttpDelete("id")]
//        [Authorize]
//        public async Task<MessageModel<bool>> Delete(int id)
//        {
//            if (id < 1)
//                return new MessageModel<bool>() { Msg = "信息有误,请稍后再试!" };
//            var products = await _context.Products.FindAsync(id);
//            if (products == null)
//                return new MessageModel<bool>() { Msg = "信息有误,请稍后再试!", Success = false };
//            var productsModel = _context.Products.Remove(products);
//            int i = await _context.SaveChangesAsync();
//            return new MessageModel<bool>() { Msg = i > 0 ? "删除成功!" : "删除失败", Success = i > 0, Response = i > 0 };
//        }


//    }
//}
