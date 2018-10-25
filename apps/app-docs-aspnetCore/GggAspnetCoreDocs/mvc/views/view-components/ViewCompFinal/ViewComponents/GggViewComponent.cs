using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewCompFinal.ViewComponents
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/views/view-components?view=aspnetcore-2.1
    /// </summary>
    public class GggViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int maxPriority, bool isDone)
        {
            /*We recommend you name the view file Default.cshtml and use the
             Views/Shared/Components/{View Component Name}/{View Name} path.*/
            string MyView = "Default";
            List<TodoItem> items = await GetItemsAsync(maxPriority, isDone);
            return View(MyView, items);
        }

        private async Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        {
            List<TodoItem> toDoList = await GetTodoList();
            return toDoList.Where(x => x.IsDone == isDone &&
                                      x.Priority <= maxPriority).ToList();
        }

        private Task<List<TodoItem>> GetTodoList()
        {
            List<TodoItem> result = new List<TodoItem>();
            for (int i = 0; i < 10; i++)
            {
                TodoItem item = new TodoItem()
                {
                    IsDone = (Guid.NewGuid().GetHashCode() % 2).Equals(0),
                    Priority = (new Random(Guid.NewGuid().GetHashCode()).Next(1, 11))
                };
                result.Add(item);
            }
            Task<List<TodoItem>> fromResult = Task.FromResult(result);
            return fromResult;
        }
    }

    public class TodoItem
    {
        public bool IsDone { get; set; }
        public int Priority { get; set; }
    }
}
