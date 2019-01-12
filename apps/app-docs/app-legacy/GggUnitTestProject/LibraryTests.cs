using GggNetStandard.Basics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GggUnitTestProject
{
    [TestClass]
    public class LibraryTests
    {
        [TestMethod]
        public void ThingGetsObjectValFromNumber()
        {
            Assert.AreEqual(42, new Thing().Get(42));
        }
    }
}
