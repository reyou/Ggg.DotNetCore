using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.hierarchyAndFailureHandling
{
    [TestClass]
    public class SupervisingActorTests : TestKit
    {
        [TestMethod]
        public void TellFail()
        {
            TestUtilities.WriteLine("SupervisingActorTests begin");
            Props props = Props.Create<SupervisingActor>();
            IActorRef supervisingActor = Sys.ActorOf(props, "supervising-actor");
            supervisingActor.Tell("failChild");
            TestUtilities.WriteLine("SupervisingActorTests Fail Child Called");
            TestUtilities.WriteLine("SupervisingActorTests end");
            TestUtilities.Sleep(3);
        }
    }
}
