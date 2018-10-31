using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    public class StartStopActor2 : UntypedActor
    {
        protected override void PreStart()
        {
            TestUtilities.WriteLine("StartStopActor2 PreStart");
            Console.WriteLine("second started");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("StartStopActor2 PostStop");
            Console.WriteLine("second stopped");
        }

        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("StartStopActor2 OnReceive: " + message);
        }
    }
}