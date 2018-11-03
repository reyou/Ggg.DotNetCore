using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.hierarchyAndFailureHandling
{
    public class SupervisingActor : UntypedActor
    {
        private IActorRef _child;
        protected override void PreStart()
        {
            Props props = Props.Create<SupervisedActor>();
            _child = Context.ActorOf(props, "supervised-actor");
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
                    TestUtilities.WriteLine("SupervisingActor OnReceive message: " + message);
                    _child.Tell("fail");
                    break;
            }
        }
    }
}
