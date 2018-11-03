using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    [TestClass]
    public class StartStopActor1Tests : TestKit
    {
        [TestMethod]
        public void TellStop()
        {
            TestUtilities.WriteLine("TellStop Init");
            Props props = Props.Create<StartStopActor1>();
            IActorRef first = Sys.ActorOf(props, "first");
            // "first: [akka://test/user/first#280316691]" ThreadId: 3
            TestUtilities.WriteLine("first: " + first);
            TestUtilities.WriteLine("StartStopActor1 Created");
            first.Tell("stop");
            TestUtilities.WriteLine("TellStop End");
            TestUtilities.Sleep(2);
        }
    }
}
