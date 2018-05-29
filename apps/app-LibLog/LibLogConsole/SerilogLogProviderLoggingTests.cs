using LibLogConsole.Logging;
using LibLogConsole.Logging.LogProviders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serilog;
using Serilog.Events;
using Logger = Serilog.Core.Logger;

namespace LibLogConsole
{
    [TestClass]
    public class SerilogLogProviderLoggingTests
    {
        private SerilogLogProvider _logProvider;
        private ILog _iLog;
        private LogEvent _logEvent;

        public SerilogLogProviderLoggingTests()
        {
            Logger logger = new LoggerConfiguration()
                .Enrich
                .FromLogContext()
                .MinimumLevel
                .Is(LogEventLevel.Verbose)
                .CreateLogger();

            Log.Logger = logger;
            _logProvider = new SerilogLogProvider();
            _iLog = new LoggerExecutionWrapper(_logProvider.GetLogger(("Test")));

        }

        [TestMethod]
        public void Should_be_able_to_log_message()
        {
            LogLevel logLevel = LogLevel.Debug;
            bool log = _iLog.Log(logLevel, () => "m");
            Assert.IsTrue(log);
        }
    }
}
