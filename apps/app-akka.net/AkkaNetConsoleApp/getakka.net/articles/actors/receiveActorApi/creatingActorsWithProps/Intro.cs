using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.creatingActorsWithProps
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html#creating-actors-with-props
    /// </summary>
    public class Intro
    {
        public Intro()
        {
            // ActorSystem is a heavy object: create only one per application
            ActorSystem system = ActorSystem.Create("MySystem");
            IActorRef myActor = system.ActorOf<MyActor>("myactor");
            TestUtilities.WriteObject(myActor);
        }
    }
}
