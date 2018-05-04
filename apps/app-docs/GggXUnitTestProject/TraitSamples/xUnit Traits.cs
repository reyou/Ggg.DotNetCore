using Xunit;

namespace GggXUnitTestProject.TraitSamples
{
    /// <summary>
    /// http://www.brendanconnolly.net/organizing-tests-with-xunit-traits/
    /// https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests#xunit
    /// Both NUnit and MSTest make use of the Category verbage. NUnit using the Category 
    /// Attribute and MSTest using the TestCategory Attribute. You might expect xUnit to 
    /// also have something named similarly, but instead they have chosen the Trait attribute.
    /// Trait: kişisel özellik
    /// </summary>
    public class XUnitTraits
    {
        // Attribute used to decorate a test method with arbitrary name/value pairs ("traits").
        [Trait("Category", "bvt")]
        [Trait("Priority", "1")]
        [Fact]
        public void foo()
        {
        }

        [Trait("Category", "Nightly")]
        [Trait("Priority", "2")]
        [Fact]
        public void bar()
        {
        }

        [Fact, Category("Trait")]
        public void ExampleFact()
        {
            Assert.True(true);
        }
    }
}
