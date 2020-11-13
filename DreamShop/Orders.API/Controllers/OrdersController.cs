using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelp;
using CommonHelp.Help;
using Identity.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Orders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IConfiguration _configuration;

        public OrdersController(ILogger<OrdersController> logger, IConfiguration configuration)
        {
            this._logger = logger;
            this._configuration = configuration;
        }
        [HttpGet]
        public async Task<MessageModel<Logins>> Get()
        {
            string result = $"【订单服务】{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}——" +
                $"{Request.HttpContext.Connection.LocalIpAddress}:{_configuration["port"]}--未熔断";
            string url = "http://localhost:5000/api/Login/Login";
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("loginName", "admin");
            dictionary.Add("loginPassword", "123");
            //var login = new { LoginName = "admin", LoginPassword = "123" };
            //var ss = ApiHelper.PostAsync<MessageModel<Logins>>(url, dictionary,"");
            var sss = new MessageModel<Logins>();
            sss = await ApiHelper.PostAsync<MessageModel<Logins>>(url, dictionary, 1);
            try
            {
                sss = await ApiHelper.PostAsync<MessageModel<Logins>>(url, dictionary, 1);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 404;
                //return new MessageModel<Logins>() { Msg = ex.Message, Success = false };
            }
            return sss;
        }
    }
}


            
       
 
