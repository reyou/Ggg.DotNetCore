using System;

namespace GggWebApplication.Controllers.LoggingExamples
{
    public class TodoRepository : ITodoRepository
    {
        public object Find(string id)
        {
            return new
            {
                Title = "Portal",
                Date = DateTime.Now
            };
        }
    }
}