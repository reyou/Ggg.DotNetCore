using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    public class PrintMyActorRefActorForNoSender : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            // "Self: [akka://test/user/first-actor#949652029]" ThreadId: 7
            TestUtilities.WriteLine("Self: " + Self);
            // "Sender: [akka://test/deadLetters]" ThreadId: 7
            TestUtilities.WriteLine("Sender: " + Sender);
            switch (message)
            {
                case "printit":
                    IActorRef secondRef = Context.ActorOf(Props.Empty, "second-actor");
                    // "secondRef: [akka://test/user/first-actor/second-actor#889423230]" ThreadId: 7
                    TestUtilities.WriteLine("secondRef: " + secondRef);
                    break;
                default:
                    TestUtilities.WriteLine("Cannot find action for message: " + message);
                    break;

            }
        }
    }
}