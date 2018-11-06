using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.gracefulStop
{
    public class Manager : ReceiveActor
    {
        private IActorRef worker = Context.Watch(Context.ActorOf<Cruncher>("worker"));

        public Manager()
        {
            Receive<string>(s => s.Equals("job"), msg =>
            {
                worker.Tell("crunch");
            });

            Receive<FSMBase.Shutdown>(_ =>
            {
                worker.Tell(PoisonPill.Instance, Self);
                Context.Become(ShuttingDown);
            });
        }

        private void ShuttingDown(object message)
        {
            Receive<string>(s => s.Equals("job"), msg =>
            {
                Sender.Tell("service unavailable, shutting down", Self);
            });

            Receive<FSMBase.Shutdown>(_ =>
            {
                Context.Stop(Self);
            });
        }

        public static Props Props()
        {
            Props props = Akka.Actor.Props.Create<Manager>();
            return props;
        }
    }
}