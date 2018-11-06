using Akka.Actor;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.askSendAndReceiveFuture
{
    public class ActorA : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (message.ToString().Equals("request"))
            {
                ProcessRequest();
            }
        }

        private void ProcessRequest()
        {
            try
            {
                object result = operation();
                Sender.Tell(result, Self);
            }
            catch (Exception e)
            {
                Sender.Tell(new Failure
                {
                    Exception = e
                }, Self);
            }
        }

        private object operation()
        {
            throw new NotImplementedException();
        }

        public static Props Props()
        {
            Props props = Akka.Actor.Props.Create<ActorA>();
            return props;
        }
    }
}