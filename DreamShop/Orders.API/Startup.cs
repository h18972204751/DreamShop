using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonHelp.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Orders.API.Data;

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

            services.AddDbContext<OrdersDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("OrderDbContext")));

            services.AddAuthentication("Bearer")
               //AddIdentityServerAuthentication�����IdentityServer4.AccessTokenValidation��  �������֧��Reference Token �� JWT ����֤
               .AddJwtBearer("Bearer", options =>
               {
                   options.Authority = "http://localhost:5000";    //����Identityserver����Ȩ��ַ
                   options.RequireHttpsMetadata = false;           //����Ҫhttps    
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false
                   };
                   //options.ApiName = OAuthConfig.UserApi.ApiName;  //api��name����Ҫ��config��������ͬ
               });
            services.AddHttpClient();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                //app.UseDeveloperExceptionPage();
                app.UseStatusCodePagesWithReExecute("/StatusCode?code={0}");
            }
            else 
            {
                app.UseStatusCodePagesWithReExecute("/StatusCode", "?code={0}");
            }

            app.UseRouting();

            app.UseAuthentication();
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
            //app.ConsulRegister(Configuration);
            //ConsulUtil.ConsulRegist(app, Configuration);

        }
    }
}
