using Akka.Actor;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.actorApi
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html#actor-api
    /// </summary>
    public class Intro : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }

        protected override void PreStart()
        {
        }

        protected override void PreRestart(Exception reason, object message)
        {
            foreach (IActorRef each in Context.GetChildren())
            {
                Context.Unwatch(each);
                Context.Stop(each);
            }
            PostStop();
        }

        protected override void PostRestart(Exception reason)
        {
            PreStart();
        }

        protected override void PostStop()
        {
        }

    }
}
