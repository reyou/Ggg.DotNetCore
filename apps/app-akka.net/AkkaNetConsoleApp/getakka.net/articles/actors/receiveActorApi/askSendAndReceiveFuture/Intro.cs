using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.askSendAndReceiveFuture
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html#ask-send-and-receive-future
    /// </summary>
    public class Intro : UntypedActor
    {
        private IActorRef actorA { get; set; }
        private IActorRef actorB { get; set; }
        private IActorRef actorC { get; set; }
        public Intro()
        {
            actorA = Context.ActorOf(ActorA.Props());
        }

        public void DoJob()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(actorA.Ask("request", TimeSpan.FromSeconds(1)));
            tasks.Add(actorB.Ask("another request", TimeSpan.FromSeconds(5)));
            Task.WhenAll(tasks).PipeTo(actorC, Self);

        }
        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }

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
                var result = operation();
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
