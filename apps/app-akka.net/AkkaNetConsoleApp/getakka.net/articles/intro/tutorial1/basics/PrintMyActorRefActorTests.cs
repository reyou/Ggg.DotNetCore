using Akka.Actor;
using Akka.TestKit.VsTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    [TestClass]
    public class PrintMyActorRefActorTests : TestKit
    {
        [TestMethod]
        public void Tell()
        {
            IActorRef actor = Sys.ActorOf<PrintMyActorRefActor>();
            actor.Tell("printit");
        }

        [TestMethod]
        public void Tell2()
        {
            IActorRef firstRef = Sys.ActorOf(Props.Create<PrintMyActorRefActor>(), "first-actor");
            Console.WriteLine($"First: {firstRef}");
            Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            firstRef.Tell("printit", ActorRefs.NoSender);
            if (Debugger.IsAttached) { Debugger.Break(); }
        }
    }
}
