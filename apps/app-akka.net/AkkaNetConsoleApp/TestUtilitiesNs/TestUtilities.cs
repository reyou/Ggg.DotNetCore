using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace AkkaNetConsoleApp.TestUtilitiesNs
{
    /// <summary>
    /// https://www.carlrippon.com/asp-net-core-logging-with-serilog-and-sql-server/
    /// https://github.com/serilog/serilog-sinks-mssqlserver
    /// </summary>
    public class TestUtilities
    {
        public static Logger Logger { get; set; }
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();
        static TestUtilities()
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomainOnProcessExit;
            Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
        }

        private static void CurrentDomainOnProcessExit(object sender, EventArgs e)
        {
            Log.CloseAndFlush();
        }

        public static void WriteLine(object messageObject)
        {
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Debug.Print(msg);
                Debugger.Break();
            });
            Console.WriteLine(messageObject);
            Logger.Information("{messageObject} ThreadId: {threadId}", messageObject, Thread.CurrentThread.ManagedThreadId);
        }

        public static void Info(string message)
        {
            WriteLine(message);
        }

        public static void Warning(string message)
        {
            WriteLine(message);
        }
    }
}
