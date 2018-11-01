using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.theRegistrationProtocol;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.addRegistrationSupportToDeviceActor
{
    public class Device : UntypedActor
    {
        private double? _lastTemperatureReading = null;

        public Device(string groupId, string deviceId)
        {
            TestUtilities.WriteLine($"Device.Constructor() groupId: {groupId}, deviceId: {deviceId}");
            GroupId = groupId;
            DeviceId = deviceId;
        }

        protected override void PreStart()
        {
            TestUtilities.Info($"Device.PreStart() Device actor {GroupId}-{DeviceId} started");
            Log.Info($"Device actor {GroupId}-{DeviceId} started");
        }
        protected override void PostStop()
        {
            TestUtilities.Info($"Device.PostStop() Device actor {GroupId}-{DeviceId} stopped");
            Log.Info($"Device actor {GroupId}-{DeviceId} stopped");
        }

        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        protected string GroupId { get; }
        protected string DeviceId { get; }

        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("Device.OnReceive() " + message);
            switch (message)
            {
                case RequestTrackDevice req when req.GroupId.Equals(GroupId) && req.DeviceId.Equals(DeviceId):
                    TestUtilities.WriteLine("Device.OnReceive() RequestTrackDevice1 " + message);
                    Sender.Tell(DeviceRegistered.Instance);
                    break;
                case RequestTrackDevice req:
                    TestUtilities.WriteLine("Device.OnReceive() RequestTrackDevice2 " + message);
                    Log.Warning($"Ignoring TrackDevice request for {req.GroupId}-{req.DeviceId}.This actor is responsible for {GroupId}-{DeviceId}.");
                    break;
                case RecordTemperature rec:
                    TestUtilities.WriteLine("Device.OnReceive() RecordTemperature " + message);
                    TestUtilities.Info($"Recorded temperature reading {rec.Value} with {rec.RequestId}");
                    Log.Info($"Recorded temperature reading {rec.Value} with {rec.RequestId}");
                    _lastTemperatureReading = rec.Value;
                    Sender.Tell(new TemperatureRecorded(rec.RequestId));
                    break;
                case ReadTemperature read:
                    TestUtilities.WriteLine("Device.OnReceive() ReadTemperature " + message);
                    Sender.Tell(new RespondTemperature(read.RequestId, _lastTemperatureReading));
                    break;
            }
        }

        public static Props Props(string groupId, string deviceId)
        {
            TestUtilities.WriteLine($"Device.Props() groupId: {groupId}, deviceId: {deviceId}");
            return Akka.Actor.Props.Create(() => new Device(groupId, deviceId));
        }
    }
}