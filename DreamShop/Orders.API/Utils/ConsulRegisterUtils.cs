using CommonHelp.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.API.Utils
{
    public static class ConsulRegisterUtils
    {
        public static void ConsulRegister(this IApplicationBuilder app, IConfiguration configuration)
        {
            var s = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true).Build();
            ConsulUtil.ConsulRegist(app, configuration);
        }



    }
}
