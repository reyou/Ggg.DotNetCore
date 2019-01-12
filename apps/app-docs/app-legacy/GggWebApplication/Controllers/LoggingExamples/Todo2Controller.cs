using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GggWebApplication.Controllers.LoggingExamples
{
    /// <summary>
    /// http://localhost:11781/ToDo2/GetById/1
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1&tabs=aspnetcore2x#log-category
    /// </summary>
    public class Todo2Controller : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;

        // Most of the time, it will be easier to use ILogger<T>, as in the following example
        public Todo2Controller(ITodoRepository todoRepository, ILoggerFactory loggerFactory)
        {
            _todoRepository = todoRepository;
            _logger = loggerFactory.CreateLogger("TodoApi.Todo2Controller.TodoController");
        }
        public IActionResult GetById(string id)
        {
            _logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
            object item = _todoRepository.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
        }

        public IActionResult GetById2(string id, string title)
        {
            TodoItem item;
            using (_logger.BeginScope("Message attached to logs created in the using block"))
            {
                _logger.LogInformation(LoggingEvents.GetItem, "Getting item {ID}", id);
                item = _todoRepository.Find(id);
                if (item == null)
                {
                    _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({ID}) NOT FOUND", id);
                    return NotFound();
                }
            }
            return new ObjectResult(item);
        }


    }
}