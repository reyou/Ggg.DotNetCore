using Akka.Actor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace UseCaseWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        //expose your endpoint as async
        public async Task<SomeResult> Post(SomeRequest someRequest)
        {
            //send a message based on your incoming arguments to one of the actors you created earlier
            //and await the result by sending the message to `Ask`
            SomeResult result = await Startup.MyActor.Ask<SomeResult>(new SomeMessage(someRequest.SomeArg1, someRequest.SomeArg2));
            return result;
        }
    }

    public class SomeMessage
    {
        public SomeMessage(object someArg1, object someArg2)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SomeRequest
    {
        public object SomeArg1 { get; set; }
        public object SomeArg2 { get; set; }
    }

    public class SomeResult
    {
    }
}
