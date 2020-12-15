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
                .AddDeveloperSigningCredential()  //添加登录证书
                .AddInMemoryIdentityResources(Config.Config.GetIdentityResources())  //添加IdentityResources
                .AddInMemoryApiScopes(Config.Config.GetApiResources())
                .AddInMemoryClients(Config.Config.GetClients())
                .AddTestUsers(Config.Config.GeTestUsers());
            services.AddAuthentication("Bearer")
               //AddIdentityServerAuthentication在组件IdentityServer4.AccessTokenValidation中  这个方法支持Reference Token 和 JWT 的认证
               .AddJwtBearer("Bearer", options =>
               {
                   options.Authority = "http://localhost:5000";    //配置Identityserver的授权地址
                   options.RequireHttpsMetadata = false;           //不需要https    
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateAudience = false
                   };
                   //options.ApiName = OAuthConfig.UserApi.ApiName;  //api的name，需要和config的名称相同
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

                //“any”表示策略名称，可以随便起，在第2步会用到；
                //AllowAnyOrigin表示允许任何域；
                //AllowAnyMethod表示允许任何方法；
                //AllowAnyHeader表示允许任何消息头。
                //如果是允许指定的域、方法、消息头需要使用WithOrigins、WithMethods、WithHeaders方法。
                //在这里可以添加多条策略。
            });
            services.AddHttpClient();

            //注册Redis
            services.AddTransient<IRedisBasketRepository, RedisBasketRepository>();
            services.AddSingleton<ConnectionMultiplexer>(sp =>
            {
                //获取连接字符串
                string redisConfiguration = Configuration.GetConnectionString("Redis");
                var configuration = ConfigurationOptions.Parse(redisConfiguration, true);
                configuration.ResolveDns = true;
                return ConnectionMultiplexer.Connect(configuration);
            });

            var builder = new ContainerBuilder();
            var assembly = this.GetType().GetTypeInfo().Assembly.GetExportedTypes().ToArray();
            var baseType = typeof(IDependency);
            //找到接口和实现类
            var types = assembly.Where(x => x != baseType && baseType.IsAssignableFrom(x)).ToList();
            //找到接口
            var implementTypes = types.Where(x => x.IsClass).ToList();
            var interfaceTypes = types.Where(x => x.IsInterface).ToList();
            foreach (var implementType in implementTypes)
            {
                //implementType实现类     找到这个实现类实现的接口
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
