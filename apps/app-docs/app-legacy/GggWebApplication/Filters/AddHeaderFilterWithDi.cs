using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GggWebApplication.Filters
{
    public class AddHeaderFilterWithDi : IFilterMetadata
    {
        public AddHeaderFilterWithDi()
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": ");
        }
    }
}