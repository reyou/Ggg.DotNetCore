using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GggWebApplication.Filters
{
    public class SampleGlobalActionFilter : IFilterMetadata
    {
        public SampleGlobalActionFilter()
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": SampleGlobalActionFilter");
        }
    }
}