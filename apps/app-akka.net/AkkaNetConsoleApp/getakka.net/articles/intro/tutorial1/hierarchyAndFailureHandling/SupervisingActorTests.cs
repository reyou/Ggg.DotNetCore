using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
{
    [TestClass]
    public class SupervisingActorTests : TestKit
    {
        [TestMethod]
        public void TellFail()
        {
            TestUtilities.WriteLine("SupervisingActorTests begin");
            IActorRef supervisingActor = Sys.ActorOf(Props.Create<SupervisingActor>(), "supervising-actor");
            supervisingActor.Tell("failChild");
            TestUtilities.WriteLine("SupervisingActorTests end");
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
    }
}
