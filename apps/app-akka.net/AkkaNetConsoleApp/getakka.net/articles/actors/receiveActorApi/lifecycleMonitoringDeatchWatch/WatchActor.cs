using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.lifecycleMonitoringDeatchWatch
{
    public class WatchActor : ReceiveActor
    {
        private IActorRef child = Context.ActorOf(Props.Empty, "child");
        private IActorRef lastSender = Context.System.DeadLetters;

        /// <summary>
        /// Right after starting the actor, its PreStart method is invoked.
        /// https://getakka.net/articles/actors/receive-actor-api.html#start-hook
        /// </summary>
        protected override void PreStart()
        {
            child = Context.ActorOf(Props.Empty);
        }
        public WatchActor()
        {
            Context.Watch(child); // <-- this is the only call needed for registration

            Receive<string>(s => s.Equals("kill"), msg =>
            {
                Context.Stop(child);
                lastSender = Sender;
            });

            Receive<Terminated>(t => t.ActorRef.Equals(child), msg =>
            {
                lastSender.Tell("finished");
            });
        }
    }

}
