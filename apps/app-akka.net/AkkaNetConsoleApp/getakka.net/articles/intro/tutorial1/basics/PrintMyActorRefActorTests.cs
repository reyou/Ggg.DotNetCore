using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    [TestClass]
    public class PrintMyActorRefActorTests : TestKit
    {
        [TestMethod]
        public void Tell()
        {
            TestUtilities.WriteLine("PrintMyActorRefActorTests Begin");
            IActorRef actor = Sys.ActorOf<PrintMyActorRefActor>();
            // "actor: [akka://test/user/$a#853780428]" ThreadId: 3
            TestUtilities.WriteLine("actor: " + actor);
            actor.Tell("printit");
            TestUtilities.WriteLine("PrintMyActorRefActorTests End");
            TestUtilities.Sleep(2);
        }
        [TestMethod]
        public void TellNoSender()
        {
            TestUtilities.WriteLine("PrintMyActorRefActorTests Begin");
            Props props = Props.Create<PrintMyActorRefActorForNoSender>();
            // "objectRef: Akka.Actor.Props" ThreadId: 3
            TestUtilities.WriteObject(props);
            IActorRef firstRef = Sys.ActorOf(props, "first-actor");
            // "objectRef: [akka://test/user/first-actor#949652029]" ThreadId: 3
            TestUtilities.WriteObject(firstRef);
            firstRef.Tell("printit", ActorRefs.NoSender);
            TestUtilities.WriteLine("PrintMyActorRefActorTests End");
            TestUtilities.Sleep(2);
        }
        [TestMethod]
        public async Task Ask()
        {
            TestUtilities.WriteLine("PrintMyActorRefActorTests Begin");
            IActorRef actor = Sys.ActorOf<PrintMyActorRefActorForAsk>();
            // "actor: [akka://test/user/$a#231127826]" ThreadId: 3
            TestUtilities.WriteLine("actor: " + actor);
            try
            {
                string asked = await actor.Ask<string>("askingSomething", TimeSpan.FromSeconds(1));
                TestUtilities.WriteObject(asked);
            }
            catch (AskTimeoutException e)
            {
                TestUtilities.WriteObject(e);
            }
            catch (Exception e)
            {
                TestUtilities.WriteLine("Unhandled Exception! See next line.");
                TestUtilities.WriteObject(e);
            }
            TestUtilities.WriteLine("PrintMyActorRefActorTests End");
            TestUtilities.Sleep(2);
        }


    }
}
