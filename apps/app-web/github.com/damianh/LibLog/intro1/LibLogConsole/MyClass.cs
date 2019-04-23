using LibLogConsole.Logging;
using System;

namespace LibLogConsole
{
    /// <summary>
    /// https://github.com/damianh/LibLog/wiki/Using
    /// </summary>
    public class MyClass
    {
        private static readonly ILog Logger = LogProvider.For<MyClass>();

        public MyClass()
        {
            using (LogProvider.OpenNestedContext("message"))
            {
                using (LogProvider.OpenMappedContext("key", "value"))
                {
                    Exception exception = new InvalidOperationException("just a fake exception.");
                    string message = "this is info message for logging.";
                    Logger.Info(exception, message, "hello", "world");
                }
            }
        }
    }

}
