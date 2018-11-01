using Akka.Actor;
using Akka.Event;
using System;
using System.Collections.Generic;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.implementingTheQuery
{
    public class DeviceGroupQuery : UntypedActor
    {
        // ReSharper disable once InconsistentNaming
        private ICancelable queryTimeoutTimer;
        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        public Dictionary<IActorRef, string> ActorToDeviceId { get; }
        public long RequestId { get; }
        public IActorRef Requester { get; }
        public TimeSpan Timeout { get; }

        public DeviceGroupQuery(Dictionary<IActorRef, string> actorToDeviceId, long requestId, IActorRef requester, TimeSpan timeout)
        {
            ActorToDeviceId = actorToDeviceId;
            RequestId = requestId;
            Requester = requester;
            Timeout = timeout;
            queryTimeoutTimer = Context.System.Scheduler.ScheduleTellOnceCancelable(timeout, Self, CollectionTimeout.Instance, Self);
        }

        protected override void PreStart()
        {
            foreach (IActorRef deviceActor in ActorToDeviceId.Keys)
            {
                Context.Watch(deviceActor);
                deviceActor.Tell(new ReadTemperature(0));
            }
        }

        protected override void PostStop()
        {
            queryTimeoutTimer.Cancel();
        }

        protected override void OnReceive(object message)
        {

        }

        public static Props Props(Dictionary<IActorRef, string> actorToDeviceId, long requestId, IActorRef requester, TimeSpan timeout)
        {
            return Akka.Actor.Props.Create(() => new DeviceGroupQuery(actorToDeviceId, requestId, requester, timeout));
        }
    }
}
