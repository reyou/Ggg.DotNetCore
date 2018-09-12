using System;
using Microsoft.Extensions.Primitives;

namespace fundamentalsProject.middleware.extensibility
{
    public class Request
    {
        public DateTime DT { get; set; }
        public string MiddlewareActivation { get; set; }
        public StringValues Value { get; set; }
    }
}