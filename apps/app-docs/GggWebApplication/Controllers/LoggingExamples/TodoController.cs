using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GggWebApplication.Controllers.LoggingExamples
{
    /// <summary>
    /// http://localhost:11781/ToDo/GetById/1
    /// </summary>
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;
        public TodoController(ITodoRepository todoRepository, ILogger<TodoController> logger)
        {
            _todoRepository = todoRepository;
            _logger = logger;
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

    }

    public class LoggingEvents
    {
        public static EventId GetItem => 1;
        public static EventId GetItemNotFound => 2;
    }
}