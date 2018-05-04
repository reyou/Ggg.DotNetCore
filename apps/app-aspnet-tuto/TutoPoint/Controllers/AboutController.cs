using Microsoft.AspNetCore.Mvc;

namespace TutoPoint.Controllers
{
    /*If you want a segment of the URL to contain the name of your controller,
     what you can do is instead of using the controller name explicitly, 
     you can use a token controller inside the square brackets. This tells ASP.NET MVC 
     to use the name of this controller in this position as shown in the following program.*/
    /*This way, if you ever rename the controller, you don't have to remember to change the
     route. The same goes for an action and implicitly there is a slash (/) between the 
     controller and the action. It is a hierarchical relationship between the controller 
     and the action just like it is inside the URL. Let us save this controller again. 
     Most probably, you will see the same results.*/

    //[Route("about")]
    [Route("[controller]")]
    public class AboutController : Controller
    {
        [Route("")]
        public string Phone()
        {
            return "+49-333-3333333";
        }

        //[Route("country")]
        [Route("[action]")]
        public string Country()
        {
            return "Germany";
        }
    }
}