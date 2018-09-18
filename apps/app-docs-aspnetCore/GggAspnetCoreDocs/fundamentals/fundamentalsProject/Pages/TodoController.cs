using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fundamentalsProject.Pages
{
    /// <summary>
    /// 
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
            var item = _todoRepository.Find(id);
            if (item == null)
            {
                _logger.LogWarning(LoggingEvents.GetItemNotFound, "GetById({ID}) NOT FOUND", id);
                return NotFound();
            }
            return new ObjectResult(item);
        }

        /// <summary>
        /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-2.1#log-scopes
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetById2(string id)
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

    public class TodoItem
    {
    }

    public class LoggingEvents
    {
        public static EventId GetItem { get; set; }
        public static EventId GetItemNotFound { get; set; }
    }

    public interface ITodoRepository
    {
        TodoItem Find(string id);
    }
}