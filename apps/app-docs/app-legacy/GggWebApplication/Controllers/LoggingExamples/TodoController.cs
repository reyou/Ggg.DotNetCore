using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GggWebApplication.Controllers.LoggingExamples
{
    /*you might write an Information log when a method ends normally,
     a Warning log when a method returns a 404 return code, and 
     an Error log when you catch an unexpected exception.*/
    /// <summary>
    /// http://localhost:11781/ToDo/GetById/1
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1&tabs=aspnetcore2x#log-category
    /// </summary>
    public class TodoController : Controller
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger _logger;

        // This is equivalent to calling CreateLogger with the fully qualified type name of T
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
}