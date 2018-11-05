using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.recommendedPractices
{
    /// <summary>
    /// Another good practice is to declare local messages
    /// (messages that are sent in process) within the Actor, which makes it easier to know what
    /// messages are generally being sent over the wire vs in process.
    /// </summary>
    public class DemoActor2 : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case DemoActorLocalMessages.DemoActorLocalMessage1 msg1:
                    // Handle message here...
                    break;
                case DemoActorLocalMessages.DemoActorLocalMessage2 msg2:
                    // Handle message here...
                    break;
                default:
                    break;
            }
        }

        private abstract class DemoActorLocalMessages
        {
            public abstract class DemoActorLocalMessage1
            {
            }

            public abstract class DemoActorLocalMessage2
            {
            }
        }
    }
}