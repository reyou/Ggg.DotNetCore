using Akka.Actor;
using Akka.Event;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.receiveTimeout
{
    public class MyActor : ReceiveActor
    {
        private ILoggingAdapter log = Context.GetLogger();

        public MyActor()
        {
            Receive<string>(s => s.Equals("Hello"), msg =>
            {
                Context.SetReceiveTimeout(TimeSpan.FromMilliseconds(100));
            });

            Receive<ReceiveTimeout>(msg =>
            {
                Context.SetReceiveTimeout(null);
                throw new Exception("Receive timed out");
            });
        }
    }
}
