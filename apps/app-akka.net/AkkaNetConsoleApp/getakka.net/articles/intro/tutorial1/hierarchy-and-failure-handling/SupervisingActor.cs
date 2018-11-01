using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
{
    public class SupervisingActor : UntypedActor
    {
        private readonly IActorRef _child = Context.ActorOf(Props.Create<SupervisedActor>(), "supervised-actor");
        protected override void PreStart()
        {
            TestUtilities.WriteLine("SupervisingActor PreStart");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("SupervisingActor PostStop");
        }
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "failChild":
                    TestUtilities.WriteLine("SupervisingActor OnReceive: " + message);
                    _child.Tell("fail");
                    break;
            }
        }
    }
}
