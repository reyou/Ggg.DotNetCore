using System.Threading.Tasks;
using DependencyInjectionSample.Interfaces;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionSample.Services
{
    #region snippet1
    /// <summary>
    /// <see cref="Startup"/>
    /// </summary>
    public class MyDependency : IMyDependency
    {
        private readonly ILogger<MyDependency> _logger;

        public MyDependency(ILogger<MyDependency> logger)
        {
            _logger = logger;
        }

        public Task WriteMessage(string message)
        {
            _logger.LogInformation(
                "MyDependency.WriteMessage called. Message: {MESSAGE}",
                message);

            return Task.FromResult(0);
        }
    }
    #endregion
}
