using System;
using Akka.Actor;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.gracefulStop
{
    internal class Cruncher : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}