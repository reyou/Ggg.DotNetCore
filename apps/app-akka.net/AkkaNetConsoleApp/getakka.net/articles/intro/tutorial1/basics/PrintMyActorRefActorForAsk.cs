using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    public class PrintMyActorRefActorForAsk : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            // "Self: [akka://test/user/$a#231127826]" ThreadId: 10
            TestUtilities.WriteLine("Self: " + Self);

            // "Sender: [akka://test/temp/c]" ThreadId: 10
            TestUtilities.WriteLine("Sender: " + Sender);

            // "secondRef: [akka://test/user/$a/second-actor#310477620]" ThreadId: 11
            IActorRef secondRef = Context.ActorOf(Props.Empty, "second-actor");
            TestUtilities.WriteLine("secondRef: " + secondRef);

            switch (message)
            {
                case "printit":
                    break;
                default:
                    TestUtilities.WriteLine("Cannot find action for message: " + message);
                    break;

            }
        }
    }
}