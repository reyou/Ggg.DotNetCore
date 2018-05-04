using System;
using Xunit.Sdk;

namespace GggXUnitTestProject.TraitSamples
{
    /// <summary>
    /// Apply this attribute to your test method to specify a category.
    /// https://github.com/xunit/samples.xunit/blob/master/TraitExtensibility/CategoryAttribute.cs
    /// </summary>
    [TraitDiscoverer("CategoryDiscoverer", "TraitExtensibility")]
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    // Represents the base class for custom attributes
    class CategoryAttribute : Attribute, ITraitAttribute
    {
        public CategoryAttribute(string category)
        {

        }
    }
}
