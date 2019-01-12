using GggNetStandard.AttributeClassSamples.Documentation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GggUnitTestProject.AttributeClassSamples.Documentation
{
    [TestClass]
    public class DemoClassIntTests
    {
        [TestMethod]
        public void RunTests()
        {
            DemoClass.Run(new[] { "" });
        }
    }
}