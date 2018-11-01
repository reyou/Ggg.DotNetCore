using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.implementingTheQuery2;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices;
using System;
using System.Collections.Generic;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.addingTheQueryCapabilityToTheGroup
{
    public class DeviceGroup : UntypedActor
    {
        private Dictionary<string, IActorRef> deviceIdToActor = new Dictionary<string, IActorRef>();
        private Dictionary<IActorRef, string> actorToDeviceId = new Dictionary<IActorRef, string>();
        private long nextCollectionId = 0L;

        public DeviceGroup(string groupId)
        {
            GroupId = groupId;
            Log = Context.GetLogger();
        }

        protected override void PreStart()
        {
            Log.Info($"Device group {GroupId} started");
        }

        protected override void PostStop()
        {
            Log.Info($"Device group {GroupId} stopped");
        }

        protected ILoggingAdapter Log { get; }
        protected string GroupId { get; }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RequestAllTemperatures r:
                    Context.ActorOf(DeviceGroupQuery.Props(actorToDeviceId, r.RequestId, Sender, TimeSpan.FromSeconds(3)));
                    break;
            }
        }

        public static Props Props(string groupId)
        {
            return Akka.Actor.Props.Create(() => new DeviceGroup(groupId));
        }
    }

}
