using Serilog;
using System;

namespace SerilogConsole
{
    /// <summary>
    /// https://github.com/serilog/serilog/wiki/Getting-Started
    /// </summary>
    public class SerilogExample
    {
        public static void Main2()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("C:\\temp\\logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("Hello world!");
            int a = 10, b = 0;
            try
            {
                Log.Debug("Dividing {A} by {B}", a, b);
                Console.WriteLine(a / b);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }
            Log.CloseAndFlush();
        }
    }
}
