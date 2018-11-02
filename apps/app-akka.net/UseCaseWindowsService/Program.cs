using System.ServiceProcess;

namespace UseCaseWindowsService
{
    /// <summary>
    /// https://getakka.net/articles/intro/use-case-and-deployment-scenarios.html#windows-service
    /// http://topshelf.readthedocs.org/en/latest/index.html
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
