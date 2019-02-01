using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GggUnitTestProject.moq4Samples
{
    /// <summary>
    /// https://github.com/moq/moq4
    /// </summary>
    [TestClass]
    public class Moq4Main
    {
        [TestMethod]
        public void MainTest()
        {
            Mock<ILoveThisFramework> mock = new Mock<ILoveThisFramework>();
            // WOW! No record/replay weirdness?! :)
            mock.Setup(framework => framework.DownloadExists("2.0.0.0")).Returns(true);

            // Use the Object property on the mock to get a reference to the object
            // implementing ILoveThisFramework, and then exercise it by calling
            // methods on it
            ILoveThisFramework lovable = mock.Object;
            bool download = lovable.DownloadExists("2.0.0.0");
            Assert.IsTrue(download);

            // Verify that the given method was indeed called with the expected value at most once
            mock.Verify(framework => framework.DownloadExists("2.0.0.0"), Times.AtMostOnce());
        }

        [TestMethod]
        public void Linq_to_Mocks()
        {
            ILoveThisFramework lovable = Mock.Of<ILoveThisFramework>(l => l.DownloadExists("2.0.0.0"));
            // Exercise the instance returned by Mock.Of by calling methods on it...
            bool download = lovable.DownloadExists("2.0.0.0");
            // Simply assert the returned state:
            Assert.IsTrue(download);
            // If you really want to go beyond state testing and want to 
            // verify the mock interaction instead...
            Mock.Get(lovable).Verify(framework => framework.DownloadExists("2.0.0.0"));
        }


    }
}
