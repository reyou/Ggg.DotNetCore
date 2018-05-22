using System;

namespace GggWebApplication.Controllers.LoggingExamples
{
    public class TodoRepository : ITodoRepository
    {
        public TodoItem Find(string id)
        {
            return new TodoItem
            {
                Title = "Portal",
                Date = DateTime.Now
            };
        }
    }
}