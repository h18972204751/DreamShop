using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using CommonHelp.Redis;
using CommonHelp.Utils;
using EventBus.Abstractions;
using Identity.API.Infrastructure;
using Identity.API.Infrastructure.IRepository;
using Identity.API.Infrastructure.Repository;
using Identity.API.Models;
//using Identity.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace Identity.API
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
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()  //��ӵ�¼֤��
                .AddInMemoryIdentityResources(Config.Config.GetIdentityResources())  //���IdentityResources
                .AddInMemoryApiScopes(Config.Config.GetApiResources())
                .AddInMemoryClients(Config.Config.GetClients())
                .AddTestUsers(Config.Config.GeTestUsers());
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
            services.AddDbContext<DreamShopUserAdminContext>(options =>
            options.UseMySql("server=49.235.230.16;userid=root;pwd=Wei19960705.;port=3306;database=dreamshop.useradmin;sslmode=none", x => x.ServerVersion("5.7.24-mysql")));

            services.AddCors(options => {
                options.AddPolicy("any", builder => 
                { 
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader(); 
                });

                //��any����ʾ�������ƣ�����������ڵ�2�����õ���
                //AllowAnyOrigin��ʾ�����κ���
                //AllowAnyMethod��ʾ�����κη�����
                //AllowAnyHeader��ʾ�����κ���Ϣͷ��
                //���������ָ�����򡢷�������Ϣͷ��Ҫʹ��WithOrigins��WithMethods��WithHeaders������
                //�����������Ӷ������ԡ�
            });
            services.AddHttpClient();

            //ע��Redis
            services.AddTransient<IRedisBasketRepository, RedisBasketRepository>();
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                //��ȡ�����ַ���
                string redisConfiguration = Configuration.GetConnectionString("Redis");
                var configuration = ConfigurationOptions.Parse(redisConfiguration, true);
                configuration.ResolveDns = true;
                return ConnectionMultiplexer.Connect(configuration);
            });

            var builder = new ContainerBuilder();
            var assembly = this.GetType().GetTypeInfo().Assembly.GetExportedTypes().ToArray();
            var baseType = typeof(IDependency);
            //�ҵ��ӿں�ʵ����
            var types = assembly.Where(x => x != baseType && baseType.IsAssignableFrom(x)).ToList();
            //�ҵ��ӿ�
            var implementTypes = types.Where(x => x.IsClass).ToList();
            var interfaceTypes = types.Where(x => x.IsInterface).ToList();
            foreach (var implementType in implementTypes)
            {
                //implementTypeʵ����     �ҵ����ʵ����ʵ�ֵĽӿ�
                var interfaceType = interfaceTypes.FirstOrDefault(x => x.IsAssignableFrom(implementType));
                if (interfaceType != null)
                    services.AddScoped(interfaceType, implementType);
            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();

            app.UseRouting();
            app.UseCors("any");
            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Home}/{action=Index}/{id?}"
                    );
            });
            //ConsulUtil.ConsulRegist(app, Configuration);
        }
    }
}
