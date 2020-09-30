using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
namespace CommonHelp.Utils
{
    public static class ConsulUtil
    {
        /// <summary>
        /// 服务注册 可传配置文件或直接传configuration在dotnet run 命令下指定端口号和地址
        /// </summary>
        /// <param name="app"></param>
        /// <param name="configuration">可传配置文件或直接传configuration在dotnet run 命令下指定端口号和地址</param>
        public static void ConsulRegist(this IApplicationBuilder app, IConfiguration configuration)
        {
            ConsulClient client = new ConsulClient(c =>
            {
                ///找到 Consul地址，默认地址
                c.Address = new Uri("http://localhost:8500");
                c.Datacenter = "dc1";
            });
            string ip = configuration["ip"];
            int weight = string.IsNullOrWhiteSpace(configuration["weight"]) ? 1 : int.Parse(configuration["weight"]);
            int port = int.Parse(configuration["port"]);//命令行参数必须传入     
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ///微服务唯一标识，唯一的
                ID = "service-" + port+"-"+Guid.NewGuid().ToString(),
                Name = "TestConsulService",//组名称-Group,同意份代码集群的组
                Address = ip,//其实应该写ip地址
                Port = port,//不同实例
                ///标签参数，可以在注册的时候根据拿到tags标签来当权重，可以是属于地址参数上的tag
                ///注册服务时指定权重，分配时获取权重并以此为依据分配实例
                Tags = new string[] { weight.ToString() },

                #region 配置心跳检查的
                Check = new AgentServiceCheck()
                {
                    ///心跳时间
                    Interval = TimeSpan.FromSeconds(30),
                    ///心跳地址
                    HTTP = $"http://{ip}:{port}/api/HealthCheck/Get",
                    ///超时时间
                    Timeout = TimeSpan.FromSeconds(5),
                    ///取消服务注册时间
                    DeregisterCriticalServiceAfter = TimeSpan.FromMinutes(1)
                }
                #endregion

            });
            Console.WriteLine($"http://{ip}:{port}完成注册");
        }
    }
}
