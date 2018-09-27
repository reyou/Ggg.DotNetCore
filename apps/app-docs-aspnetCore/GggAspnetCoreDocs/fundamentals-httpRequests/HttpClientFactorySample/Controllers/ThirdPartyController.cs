using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace HttpClientFactorySample.Controllers
{
    public class ThirdPartyController : Controller
    {
        [Route("unreliable")]
        public IActionResult UnreliableEndpoint()
        {
            int second = DateTime.UtcNow.Second;

            // about 50% of the time this will fail
            return second % 2 != 0 ? Ok() : StatusCode((int)HttpStatusCode.ServiceUnavailable);
        }
    }
}