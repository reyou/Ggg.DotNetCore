using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fundamentalsProject.dependencyInjection
{
    public class IndexModel : PageModel
    {
        MyDependency2 _dependency = new MyDependency2();

        public async Task OnGetAsync()
        {
            await _dependency.WriteMessage(
                "IndexModel.OnGetAsync created this message.");
        }
    }

    internal class MyDependency2
    {
        public Task WriteMessage(string indexmodelOngetasyncCreatedThisMessage)
        {
            throw new System.NotImplementedException();
        }
    }
}