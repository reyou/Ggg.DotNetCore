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
        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        protected string GroupId { get; }

        public DeviceGroup(string groupId)
        {
            GroupId = groupId;
        }

        protected override void PreStart()
        {
            TestUtilities.Info($"DeviceGroup.PreStart() Device group {GroupId} started");
            // Log.Info($"DeviceGroup.PreStart() Device group {GroupId} started");
        }

        protected override void PostStop()
        {
            TestUtilities.Info($"DeviceGroup.PostStop() Device group {GroupId} stopped");
            // Log.Info($"DeviceGroup.PostStop() Device group {GroupId} stopped");
        }

        protected override void OnReceive(object message)
        {
            // "DeviceGroup.OnReceive() Self: [akka://test/user/$a#1567413838]" ThreadId: 10
            TestUtilities.WriteLine("DeviceGroup.OnReceive() Self: " + Self);

            // "DeviceGroup.OnReceive() Sender: [akka://test/system/testActor2#1058686348]" ThreadId: 10
            TestUtilities.WriteLine("DeviceGroup.OnReceive() Sender: " + Sender);

            TestUtilities.WriteLine("DeviceGroup.OnReceive() message: " + message);
            switch (message)
            {
                // if device belongs to specific group
                case RequestTrackDevice trackMsg when trackMsg.GroupId.Equals(GroupId):
                    // if device added into list
                    if (_deviceIdToActor.TryGetValue(trackMsg.DeviceId, out IActorRef actorRef))
                    {
                        TestUtilities.WriteLine("DeviceGroup.OnReceive() deviceFound: " + actorRef);
                        actorRef.Forward(trackMsg);
                    }
                    // add device into the list
                    else
                    {
                        TestUtilities.WriteLine("DeviceGroup.OnReceive() deviceNotFound: " + message);
                        Props props = Device.Props(trackMsg.GroupId, trackMsg.DeviceId);
                        IActorRef deviceActor = Context.ActorOf(props, $"device-{trackMsg.DeviceId}");
                        _deviceIdToActor.Add(trackMsg.DeviceId, deviceActor);
                        // "DeviceGroup.OnReceive() deviceCreated: [akka://test/user/$a/device-device1#1964256184]" ThreadId: 10
                        TestUtilities.WriteLine("DeviceGroup.OnReceive() deviceCreated: " + deviceActor);
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
            Props props = Akka.Actor.Props.Create(() => new DeviceGroup(groupId));
            return props;
        }
    }

}
