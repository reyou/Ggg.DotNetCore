using Akka.Actor;
using Akka.TestKit.VsTest;
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
            IActorRef supervisingActor = Sys.ActorOf(Props.Create<SupervisingActor>(), "supervising-actor");
            supervisingActor.Tell("failChild");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }
}
