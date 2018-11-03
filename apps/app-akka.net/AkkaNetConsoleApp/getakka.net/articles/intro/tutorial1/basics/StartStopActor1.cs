using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    public class StartStopActor1 : UntypedActor
    {
        protected override void PreStart()
        {
            TestUtilities.WriteLine("StartStopActor1 PreStart");
            Props props = Props.Create<StartStopActor2>();
            Context.ActorOf(props, "second");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("StartStopActor1 PostStop");
        }

        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("StartStopActor1 OnReceive: " + message);
            switch (message)
            {
                case "stop":
                    Context.Stop(Self);
                    TestUtilities.WriteLine("StartStopActor1 Context.Stop(Self): " + Self);
                    break;
            }
        }
    }
}
