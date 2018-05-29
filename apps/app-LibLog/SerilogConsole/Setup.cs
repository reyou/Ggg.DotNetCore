using Serilog;
using Serilog.Core;

namespace SerilogConsole
{
    /// <summary>
    /// https://github.com/serilog/serilog/wiki/Getting-Started
    /// Configuring and using the Log class is an optional convenience that makes
    /// it easier for libraries to adopt Serilog. Serilog does not require any
    /// static/process-wide state within the logging pipeline itself, so using
    /// ILogger directly is fine.
    /// </summary>
    public class Setup
    {
        public Setup()
        {
            //  An ILogger is created using LoggerConfiguration.
            Logger log = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            // This is typically done once at application start-up, and
            // the logger saved for later use by application classes.
            // Multiple loggers can be created and used independently if required.
            log.Information("Hello, Serilog!");

            // Serilog's global, statically accessible logger, is set via Log.Logger
            // and can be invoked using the static methods on the Log class.
            Log.Logger = log;
            Log.Information("The global logger has been configured");
        }
    }
}
