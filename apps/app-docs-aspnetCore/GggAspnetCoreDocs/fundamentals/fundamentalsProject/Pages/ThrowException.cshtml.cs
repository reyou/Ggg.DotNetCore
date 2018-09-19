using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fundamentalsProject.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fundamentalsProject.Pages
{
    /// <summary>
    /// http://localhost:50312/ThrowException
    /// </summary>
    public class ThrowExceptionModel : PageModel
    {
        public void OnGet()
        {
            Exception exception = new Exception("Custom Exception");
            throw new GggGenericException(exception);
        }
    }
}