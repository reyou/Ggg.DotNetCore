using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.addRegistrationSupportToDeviceActor;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.theRegistrationProtocol;
using AkkaNetConsoleApp.TestUtilitiesNs;
using System.Collections.Generic;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.deviceGroup
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-3.html#device-group
    /// </summary>
    public class DeviceGroup : UntypedActor
    {
        private readonly Dictionary<string, IActorRef> _deviceIdToActor = new Dictionary<string, IActorRef>();

        public DeviceGroup(string groupId)
        {
            GroupId = groupId;
        }

        protected override void PreStart()
        {
            TestUtilities.Info($"DeviceGroup.PreStart() Device group {GroupId} started");
            Log.Info($"DeviceGroup.PreStart() Device group {GroupId} started");
        }

        protected override void PostStop()
        {
            TestUtilities.Info($"DeviceGroup.PostStop() Device group {GroupId} stopped");
            Log.Info($"DeviceGroup.PostStop() Device group {GroupId} stopped");
        }

        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        protected string GroupId { get; }

        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("DeviceGroup.OnReceive() " + message);
            switch (message)
            {
                case RequestTrackDevice trackMsg when trackMsg.GroupId.Equals(GroupId):
                    if (_deviceIdToActor.TryGetValue(trackMsg.DeviceId, out IActorRef actorRef))
                    {
                        actorRef.Forward(trackMsg);
                    }
                    else
                    {
                        TestUtilities.Info($"DeviceGroup.OnReceive() Creating device actor for {trackMsg.DeviceId}");
                        Log.Info($"Creating device actor for {trackMsg.DeviceId}");
                        IActorRef deviceActor = Context.ActorOf(Device.Props(trackMsg.GroupId, trackMsg.DeviceId), $"device-{trackMsg.DeviceId}");
                        _deviceIdToActor.Add(trackMsg.DeviceId, deviceActor);
                        deviceActor.Forward(trackMsg);
                    }
                    break;
                case RequestTrackDevice trackMsg:
                    TestUtilities.Warning($"DeviceGroup.OnReceive() Ignoring TrackDevice request for {trackMsg.GroupId}. This actor is responsible for {GroupId}.");
                    Log.Warning($"DeviceGroup.OnReceive() Ignoring TrackDevice request for {trackMsg.GroupId}. This actor is responsible for {GroupId}.");
                    break;
                default:
                    TestUtilities.WriteLine("DeviceGroup.OnReceive() no case statement match for message: " + message);
                    break;
            }
        }

        public static Props Props(string groupId)
        {
            TestUtilities.WriteLine($"DeviceGroup.Props() groupId: {groupId}");
            return Akka.Actor.Props.Create(() => new DeviceGroup(groupId));
        }
    }

}
