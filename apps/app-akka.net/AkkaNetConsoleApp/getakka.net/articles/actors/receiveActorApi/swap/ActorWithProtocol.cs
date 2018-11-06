using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.swap
{
    public class ActorWithProtocol : ReceiveActor, IWithUnboundedStash
    {
        public IStash Stash { get; set; }

        public ActorWithProtocol()
        {
            Receive<string>(s => s.Equals("open"), open =>
            {
                Stash.UnstashAll();

                BecomeStacked(() =>
                {
                    Receive<string>(s => s.Equals("write"), write =>
                    {
                        // do writing...
                    });

                    Receive<string>(s => s.Equals("close"), write =>
                    {
                        Stash.UnstashAll();
                        Context.UnbecomeStacked();
                    });

                    ReceiveAny(_ => Stash.Stash());
                });
            });

            ReceiveAny(_ => Stash.Stash());
        }
    }

}
