using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommonHelp.Utils;
using EventBus;
using EventBus.Abstractions;
using EventBusRabbitMQ;
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
using Orders.API.IntegrationEvents.EventHandling;
using Orders.API.IntegrationEvents.Events;
using RabbitMQ.Client;

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
            options.UseSqlServer(Configuration.GetConnectionString("OrdersDbContext")));

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
            services.AddHttpClient();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp=> {

                //var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"],
                    DispatchConsumersAsync = true
                };
                if (!string.IsNullOrEmpty(Configuration["EventBusUserName"]))
                {
                    factory.UserName = Configuration["EventBusUserName"];
                }

                if (!string.IsNullOrEmpty(Configuration["EventBusPassword"]))
                {
                    factory.Password = Configuration["EventBusPassword"];
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }
                return new DefaultRabbitMQPersistentConnection(factory,  retryCount);
            });
            var subscriptionClientName = Configuration["SubscriptionClientName"];
            services.AddSingleton<IEventBus, EventBusRabbitMQ.EventBusRabbitMQ>(sp =>
            {
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ.EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(Configuration["EventBusRetryCount"]))
                {
                    retryCount = int.Parse(Configuration["EventBusRetryCount"]);
                }

                return new EventBusRabbitMQ.EventBusRabbitMQ(rabbitMQPersistentConnection, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            var container = new ContainerBuilder();
            container.Populate(services);

            new AutofacServiceProvider(container.Build());
        }

        //绑定RoutingKey与队列
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<ProductPriceChangedIntegrationEvent, ProductPriceChangedIntegrationEventHandler>();
            //eventBus.Subscribe<OrderStartedIntegrationEvent, OrderStartedIntegrationEventHandler>();
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
            //Consu服务注册
            //app.ConsulRegister();

            ///服务注册consul
            ///启动的时候已经完成注册，这里可能会有疑惑，当请求来的时候会不会再注册一次
            ///这里管道逻辑是请求的时候已经返回了，不会执行这个注册了
            //app.ConsulRegister(Configuration);
            //ConsulUtil.ConsulRegist(app, Configuration);
            ConfigureEventBus(app);
        }
    }
}
