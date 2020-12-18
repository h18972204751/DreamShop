using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonHelp.Help
{
    public static class LogExtension
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="context"></param>
        /// <param name="elasticConfig"></param>
        public static void UseSeriLog(this IConfiguration context, ElasticConfig elasticConfig)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Debug()
#else
                .MinimumLevel.Information()
#endif
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Async(x => x.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticConfig.ElasticUri))
                {
                    LevelSwitch = new Serilog.Core.LoggingLevelSwitch(LogEventLevel.Error),
                    AutoRegisterTemplate = true,
                    AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv7,
                    IndexFormat = elasticConfig.IndexFormat,
                    FailureCallback = e => Console.WriteLine("错误信息" + e.MessageTemplate + ", " + e.Exception?.Message),
                    ModifyConnectionSettings = x => { return x.BasicAuthentication(elasticConfig.UserName, elasticConfig.PassWord); },
                    EmitEventFailure = EmitEventFailureHandling.RaiseCallback
                }))
                .WriteTo.Async(x => x.Console())
                .CreateLogger();
        }
    }
}
