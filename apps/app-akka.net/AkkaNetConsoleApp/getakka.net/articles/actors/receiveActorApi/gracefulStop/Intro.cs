using Akka.Actor;
using System;
using System.Threading.Tasks;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.gracefulStop
{
    /// <summary>
    /// https://getakka.net/articles/actors/receive-actor-api.html#graceful-stop
    /// </summary>
    public class Intro : UntypedActor
    {
        public async Task DoWork()
        {
            try
            {
                Props managerProps = Manager.Props();
                IActorRef manager = Context.ActorOf(managerProps);
                await manager.GracefulStop(TimeSpan.FromMilliseconds(5), "shutdown");
                // the actor has been stopped
            }
            catch (TaskCanceledException)
            {
                // the actor wasn't stopped within 5 seconds
            }
        }

        protected override void OnReceive(object message)
        {
            throw new NotImplementedException();
        }
    }
}