using Akka.Actor;
using Akka.Event;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.becomeUnbecome
{
    public class Swapper : ReceiveActor
    {
        public class Swap
        {
            public static Swap Instance = new Swap();
            private Swap() { }
        }
        private ILoggingAdapter log = Context.GetLogger();
        private static string SWAP = "SWAP";

        public Swapper()
        {
            Receive<Swap>(swap1 =>
            {
                log.Info("Hi");
                /*Changes the actor's behavior and replaces the current receive handler with the
                 specified handler. The current handler is stored on a stack, and you can revert to it 
                 by calling Unbecome​Stacked() Please note, that in order to not leak memory, make sure 
                 every call to Become​Stacked(Untyped​Receive) is matched with a call to Unbecome​Stacked().*/
                BecomeStacked(() =>
                {
                    Receive<Swap>(swap2 =>
                    {
                        log.Info("Ho");
                        UnbecomeStacked();
                    });
                });
            });
        }
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("MySystem");
            IActorRef swapper = system.ActorOf<Swapper>();

            swapper.Tell(Swapper.SWAP);
            swapper.Tell(Swapper.SWAP);
            swapper.Tell(Swapper.SWAP);
            swapper.Tell(Swapper.SWAP);
            swapper.Tell(Swapper.SWAP);
            swapper.Tell(Swapper.SWAP);
        }

    }
}
