using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
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
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
    }
}
