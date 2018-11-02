﻿using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-1.html#structure-of-an-iactorref-and-paths-of-actors
    /// </summary>
    public class PrintMyActorRefActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            // "Self: [akka://test/user/$a#853780428]" ThreadId: 10
            TestUtilities.WriteLine("Self: " + Self);
            // "Sender: [akka://test/system/testActor1#533240652]" ThreadId: 10
            TestUtilities.WriteLine("Sender: " + Sender);
            switch (message)
            {
                case "printit":
                    IActorRef secondRef = Context.ActorOf(Props.Empty, "second-actor");
                    // "secondRef: [akka://test/user/$a/second-actor#289243848]" ThreadId: 10
                    TestUtilities.WriteLine("secondRef: " + secondRef);
                    break;
                default:
                    TestUtilities.WriteLine("Cannot find action for message: " + message);
                    break;

            }
        }
    }
}
