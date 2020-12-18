using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsHelp.MiddleWare
{
    /// <summary>
    /// 自定义的错误处理类
    /// </summary>
    public class CostomErrorMiddle
    {
        private readonly RequestDelegate next;
        private IHostingEnvironment environment;
        /// <summary>
        /// DI,注入logger和环境变量
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        /// <param name="environment"></param>
        public CostomErrorMiddle(RequestDelegate next, IHostingEnvironment environment)
        {
            this.next = next;
            this.environment = environment;
        }
        /// <summary>
        /// 实现Invoke方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex);
            }
        }
        /// <summary>
        /// 错误信息处理方法
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private async Task HandleError(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "text/json;charset=utf-8;";
            string errorMsg = $"当前时间：{DateTime.Now},主机:{context.Request.Host}=====================请求方法:{context.Request.Path}\t\n 错误消息:{ex.Message}{Environment.NewLine}错误追踪:{ex.StackTrace}";
            //无论是否为开发环境都记录错误日志
            Log.Logger.Error(errorMsg);
            //浏览器在开发环境显示详细错误信息,其他环境隐藏错误信息
            if (environment.IsDevelopment())
            {
                await context.Response.WriteAsync(errorMsg);
            }
            else
            {
                await context.Response.WriteAsync("抱歉，服务端出错了");
            }
        }
    }
}
