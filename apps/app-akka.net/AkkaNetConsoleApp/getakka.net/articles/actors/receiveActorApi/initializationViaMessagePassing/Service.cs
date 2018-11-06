using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.initializationViaMessagePassing
{
    public class Service : ReceiveActor
    {
        private string _initializeMe;

        public Service()
        {
            Receive<string>(s => s.Equals("init"), init =>
            {
                _initializeMe = "Up and running";

                Become(() =>
                {
                    Receive<string>(s => s.Equals("U OK?") && _initializeMe != null, m =>
                    {
                        Sender.Tell(_initializeMe, Self);
                    });
                });
            });
        }
    }
}
