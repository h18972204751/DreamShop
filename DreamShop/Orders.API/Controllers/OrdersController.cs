using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelp;
using CommonHelp.Help;
using EventBus.Abstractions;
//using Identity.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orders.API.IntegrationEvents.Events;

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEventBus _eventBus;
        public OrdersController(ILogger<OrdersController> logger, IConfiguration configuration, IEventBus eventBus)
        {
            this._logger = logger;
            this._configuration = configuration;
            this._eventBus = eventBus;
        }
        [HttpGet]
        //public async Task<MessageModel<Logins>> Get()
        //{
        //    string result = $"【订单服务】{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}——" +
        //        $"{Request.HttpContext.Connection.LocalIpAddress}:{_configuration["port"]}--未熔断";
        //    string url = "http://localhost:5000/api/Login/Login";
        //    var dictionary = new Dictionary<string, string>();
        //    dictionary.Add("loginName", "admin");
        //    dictionary.Add("loginPassword", "123");
        //    //var login = new { LoginName = "admin", LoginPassword = "123" };
        //    //var ss = ApiHelper.PostAsync<MessageModel<Logins>>(url, dictionary,"");
        //    var sss = new MessageModel<Logins>();
        //    sss = await ApiHelper.PostAsync<MessageModel<Logins>>(url, dictionary, 1);
        //    try
        //    {
        //        sss = await ApiHelper.PostAsync<MessageModel<Logins>>(url, dictionary, 1);
        //    }
        //    catch (Exception ex)
        //    {
        //        HttpContext.Response.StatusCode = 404;
        //        //return new MessageModel<Logins>() { Msg = ex.Message, Success = false };
        //    }
        //    return sss;
        //}

        public async Task<string> Get()
        {
            string result = $"【订单服务】{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}——" +
                $"{Request.HttpContext.Connection.LocalIpAddress}:{_configuration["port"]}--未熔断";
            return result;
        }


        [HttpPost]
        public async Task<bool> Post()
        {
            try
            {
                
                    var pro = new ProductPriceChangedIntegrationEvent()
                    {
                        ProductTypeId=1,
                        Name="123",
                        Code="456",
                    };
                Console.WriteLine("发布");
                    _eventBus.Publish(pro);
                Console.WriteLine("发布");
                return true;
            }
            catch (Exception)
            {

                return true;
            }
        }


    }
}


            
       
 
