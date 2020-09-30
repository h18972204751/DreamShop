using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelp.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orders.API.Utils;

namespace Orders.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //Consu����ע��
            //app.ConsulRegister();

            ///����ע��consul
            ///������ʱ���Ѿ����ע�ᣬ������ܻ����ɻ󣬵���������ʱ��᲻����ע��һ��
            ///����ܵ��߼��������ʱ���Ѿ������ˣ�����ִ�����ע����
            app.ConsulRegister(Configuration);


        }
    }
}
