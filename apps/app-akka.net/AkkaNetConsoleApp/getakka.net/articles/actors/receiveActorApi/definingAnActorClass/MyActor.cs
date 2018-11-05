using Akka.Actor;
using Akka.Event;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.definingAnActorClass
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html
    /// </summary>
    public class MyActor : ReceiveActor
    {
        private readonly ILoggingAdapter log = Context.GetLogger();

        public MyActor()
        {
            Receive<string>(message =>
            {
                log.Info("Received String message: {0}", message);
                Sender.Tell(message);
            });
            Receive<SomeMessage>(message =>
            {

            });
        }
    }
}
