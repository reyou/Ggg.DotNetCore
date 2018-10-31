using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    public class StartStopActor1 : UntypedActor
    {
        protected override void PreStart()
        {
            TestUtilities.WriteLine("StartStopActor1 PreStart");
            Console.WriteLine("first started");
            Context.ActorOf(Props.Create<StartStopActor2>(), "second");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("StartStopActor1 PostStop");
            Console.WriteLine("first stopped");
        }

        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("StartStopActor1 OnReceive: " + message);
            switch (message)
            {
                case "stop":
                    Context.Stop(Self);
                    TestUtilities.WriteLine("StartStopActor1 Context.Stop(Self)");
                    break;
            }
        }
    }
}
