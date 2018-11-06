using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.becomeUnbecome
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html#becomeunbecome
    /// Akka supports hotswapping the Actor’s message loop (e.g. its implementation)
    /// at runtime. Use the Context.Become method from within the Actor.
    /// The hotswapped code is kept in a Stack which can be pushed
    /// (replacing or adding at the top) and popped.
    /// </summary>
    public class HotSwapActor : ReceiveActor
    {
        public HotSwapActor()
        {
            Receive<string>(s => s.Equals("foo"), msg =>
            {
                Become(Angry);
            });

            Receive<string>(s => s.Equals("bar"), msg =>
            {
                Become(Happy);
            });
        }

        private void Angry(object message)
        {
            Receive<string>(s => s.Equals("foo"), msg =>
            {
                Sender.Tell("I am already angry?");
            });

            Receive<string>(s => s.Equals("bar"), msg =>
            {
                Become(Happy);
            });
        }

        private void Happy(object message)
        {
            Receive<string>(s => s.Equals("foo"), msg =>
            {
                Sender.Tell("I am already happy :-)");
            });

            Receive<string>(s => s.Equals("bar"), msg =>
            {
                Become(Angry);
            });
        }
    }
}
