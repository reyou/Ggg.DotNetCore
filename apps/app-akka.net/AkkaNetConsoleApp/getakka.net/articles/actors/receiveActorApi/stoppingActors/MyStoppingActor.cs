using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.stoppingActors
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html#stopping-actors
    /// </summary>
    public class MyStoppingActor : ReceiveActor
    {
        private IActorRef child;

        public MyStoppingActor()
        {
            Receive<string>(s => s.Equals("interrupt-child"), msg =>
            {
                Context.Stop(child);
            });

            Receive<string>(s => s.Equals("done"), msg =>
            {
                Context.Stop(Self);
            });
        }
    }
}
