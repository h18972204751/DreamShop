using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Orders.API.Controllers
{
    /// <summary>
    /// 健康检查
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// 健康检查接口
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get() => "ok";
    }
}
