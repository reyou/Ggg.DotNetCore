using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-1.html#the-first-actor
    /// </summary>
    public class IotSupervisor : UntypedActor
    {
        public ILoggingAdapter Log { get; } = Context.GetLogger();

        protected override void PreStart()
        {
            TestUtilities.WriteLine("IotSupervisor PreStart");
            Log.Info("IoT Application started");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("IotSupervisor PostStop");
            Log.Info("IoT Application stopped");
        }

        // No need to handle any messages
        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("IotSupervisor OnReceive");
        }

        public static Props Props()
        {
            TestUtilities.WriteLine("IotSupervisor Props");
            return Akka.Actor.Props.Create<IotSupervisor>();
        }
    }
}
