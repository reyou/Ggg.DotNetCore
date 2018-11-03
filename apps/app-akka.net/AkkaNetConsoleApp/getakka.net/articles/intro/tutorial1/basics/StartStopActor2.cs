using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    public class StartStopActor2 : UntypedActor
    {
        protected override void PreStart()
        {
            TestUtilities.WriteLine("StartStopActor2 PreStart");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("StartStopActor2 PostStop");
        }

        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("StartStopActor2 OnReceive: " + message);
        }
    }
}