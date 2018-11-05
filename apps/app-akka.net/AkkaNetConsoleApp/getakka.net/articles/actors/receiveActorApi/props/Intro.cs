using Akka.Actor;
using AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.definingAnActorClass;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.props
{
    public class Intro
    {
        public Intro()
        {
            Props props1 = Props.Create(typeof(MyActor));
            Props props2 = Props.Create(() => new MyActorWithArgs("arg"));
            Props props3 = Props.Create<MyActor>();
            Props props4 = Props.Create(typeof(MyActorWithArgs), "arg");
        }
    }
}
