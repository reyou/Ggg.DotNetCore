using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace intro.IntroClasses
{
    /// <summary>
    /// Specifies the contracts for a view location expander that is
    /// used by Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine instances to
    /// determine search paths for a view.
    /// </summary>
    public sealed class TenantViewLocationExpander : IViewLocationExpander
    {
        private ITenantService _service;
        private string _tenant;

        /// <summary>
        /// Invoked by a Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine to determine
        /// the values that would be consumed by this instance of Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander.
        /// The calculated values are used to determine if the view location
        /// has changed since the last time it was located.
        /// </summary>
        /// <param name="context"></param>
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            // Gets or sets the System.IServiceProvider that
            // provides access to the request's service container.
            _service = (ITenantService)context.ActionContext.HttpContext.RequestServices.GetService(typeof(ITenantService));
            _tenant = this._service.GetCurrentTenant();
        }

        /// <summary>
        /// Invoked by a Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine
        /// to determine potential locations for a view.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="viewLocations"></param>
        /// <returns></returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            foreach (string location in viewLocations)
            {
                yield return location.Replace("{0}", _tenant + "/{0}");
                yield return location;
            }
        }
    }

}
