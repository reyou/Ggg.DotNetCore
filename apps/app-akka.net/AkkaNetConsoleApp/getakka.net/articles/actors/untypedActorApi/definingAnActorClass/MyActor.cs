using Akka.Actor;
using Akka.Event;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.untypedActorApi.definingAnActorClass
{
    public class MyActor : UntypedActor
    {
        private ILoggingAdapter log = Context.GetLogger();

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "test":
                    log.Info("received test");
                    break;
                default:
                    log.Info("received unknown message");
                    break;
            }
        }
    }

}
