using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace intro.IntroClasses
{
    [HtmlTargetElement("tenant")]
    public class TenantTagHelper : TagHelper
    {
        private readonly ITenantService _service;
        [HtmlAttributeName("name")]
        public string Name { get; set; }
        public TenantTagHelper(ITenantService service)
        {
            this._service = service;
        }
        /// <summary>
        /// Asynchronously executes the Microsoft.AspNetCore.Razor.TagHelpers.TagHelper with the given context and output. 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            string tenant = Name ?? string.Empty;

            if (tenant != _service.GetCurrentTenant())
            {
                // Changes Microsoft.AspNetCore.Razor.TagHelpers.TagHelperOutput to generate nothing.
                output.SuppressOutput();
            }

            // Asynchronously executes the Microsoft.AspNetCore.Razor.TagHelpers.TagHelper with the given context and output.
            return base.ProcessAsync(context, output);
        }
    }
}
