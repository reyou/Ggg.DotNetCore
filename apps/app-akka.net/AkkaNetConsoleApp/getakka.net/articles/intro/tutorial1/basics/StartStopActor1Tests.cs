using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    [TestClass]
    public class StartStopActor1Tests : TestKit
    {
        [TestMethod]
        public void TellStop()
        {
            TestUtilities.WriteLine("TellStop Init");
            IActorRef first = Sys.ActorOf(Props.Create<StartStopActor1>(), "first");
            TestUtilities.WriteLine("StartStopActor1 Created");
            first.Tell("stop");
            TestUtilities.WriteLine("TellStop End");
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
