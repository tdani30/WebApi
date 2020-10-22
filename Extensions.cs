using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Interfaces;
using WebApi.Services.Loggers;

namespace WebApi
{
    public static class Extensions
    {
        public static void AddLoggers(this IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("Logging:Loggers").Get<string[]>();

            string appName = "Servey";
            bool includeDebugInfo = true;
            string logFile = Path.Combine(Directory.GetCurrentDirectory(), "log.txt");

            var aggregateLogger = new AggregateLogger(includeDebugInfo);


            if (section.Contains(InMemoryLogger.Key))
            {
                var memLogger = new InMemoryLogger(appName, includeDebugInfo);
                aggregateLogger.AddLogger(memLogger);
                services.AddSingleton<InMemoryLogger>(memLogger);
            }

            if (section.Contains(FileLogger.Key))
            {
                var fileLogger = new FileLogger(logFile, appName, includeDebugInfo);
                aggregateLogger.AddLogger(fileLogger);
                services.AddSingleton<FileLogger>(fileLogger);
            }

            if (section.Contains(DebugWindowLogger.Key))
            {
                var debugLogger = new DebugWindowLogger(appName, includeDebugInfo);
                aggregateLogger.AddLogger(debugLogger);
                services.AddSingleton<DebugWindowLogger>(debugLogger);
            }

            services.AddSingleton<ILogger>(aggregateLogger);
            aggregateLogger.Log("Startup", "Application starting, Configuring services...");
        }
    }
    public class DebugWindowLogger : LoggerBase
    {
        public static string Key = "DebugWindow";
        public DebugWindowLogger(string applicationName, bool includeDebugInfo)
              : base(applicationName, includeDebugInfo)
        {
        }

        public override void Log(string source, string message, LogLevel logLevel = LogLevel.Information)
        {
            Debug.WriteLine(new LogRecord
            {
                Content = message,
                Source = source,
                Level = logLevel,
                Application = _application,
                Date = DateTime.Now
            }.ToString());
        }

        public override void Dispose()
        { }
    }
}
