using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.creatingActorsWithProps
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html#creating-actors-with-props
    /// </summary>
    public class FirstActor : ReceiveActor
    {
        IActorRef child = Context.ActorOf<MyActor>("myChild");
        // plus some behavior ...
        public FirstActor()
        {
            TestUtilities.WriteObject(child);
        }
    }
}