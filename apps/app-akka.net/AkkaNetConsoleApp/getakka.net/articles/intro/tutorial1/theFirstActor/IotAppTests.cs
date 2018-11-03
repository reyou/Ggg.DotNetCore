using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.theFirstActor
{
    [TestClass]
    public class IotAppTests
    {
        [TestMethod]
        public void Init()
        {
            TestUtilities.WriteLine("IotAppTests Begin");
            IotApp.Init();
            TestUtilities.WriteLine("IotAppTests End");
            TestUtilities.Sleep(3);
        }
    }
}
