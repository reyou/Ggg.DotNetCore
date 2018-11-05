using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.recommendedPractices
{
    [TestClass]
    public class DemoActorTests : TestKit
    {
        [TestMethod]
        public void Qqq()
        {
            IActorRef actorRef = Sys.ActorOf(DemoActor.Props(42), "demo");
            TestUtilities.WriteObject(actorRef);
        }

    }
}

