using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.recommendedPractices
{
    public class DemoActor : ReceiveActor
    {
        private readonly int _magicNumber;

        public DemoActor(int magicNumber)
        {
            _magicNumber = magicNumber;
            Receive<int>(x =>
            {
                Sender.Tell(x + _magicNumber);
            });
        }

        public static Props Props(int magicNumber)
        {
            return Akka.Actor.Props.Create(() => new DemoActor(magicNumber));
        }
    }
}
