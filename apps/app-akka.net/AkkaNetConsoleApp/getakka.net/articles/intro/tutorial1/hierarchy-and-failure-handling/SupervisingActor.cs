using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
{
    public class SupervisingActor : UntypedActor
    {
        private IActorRef child = Context.ActorOf(Props.Create<SupervisedActor>(), "supervised-actor");
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "failChild":
                    child.Tell("fail");
                    break;
            }
        }
    }
}
