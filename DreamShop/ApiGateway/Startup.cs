using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;

namespace ApiGateway
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // var authenticationProviderKey = "dream";

            //services.AddAuthentication()
            //    .AddIdentityServerAuthentication(authenticationProviderKey, options => {
            //        options.Authority = "http://localhost:1110/";
            //        options.ApiName = "gateway_api";
            //        options.SupportedTokens = SupportedTokens.Both;
            //        options.ApiSecret = "secret";
            //        options.RequireHttpsMetadata = false;
            //    });
            services.AddOcelot().AddConsul().AddPolly();
            //services.AddOcelot().AddConsul().AddPolly();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            //app.UseOcelot();
             app.UseOcelot().Wait();
        }
    }
}
