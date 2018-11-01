using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.TestUtilitiesNs;

// ReSharper disable once CheckNamespace
namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.write
{
    public class Device : UntypedActor
    {
        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        protected string GroupId { get; }
        protected string DeviceId { get; }
        private double? _lastTemperatureReading = null;
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
        public Device(string groupId, string deviceId)
        {
            TestUtilities.WriteLine($"Device.Constructor() groupId: {groupId}, deviceId: {deviceId}");
            GroupId = groupId;
            DeviceId = deviceId;
        }
        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("Device.OnReceive() " + message);
            switch (message)
            {
                case RecordTemperature rec:
                    TestUtilities.Info($"Device.OnReceive() Recorded temperature reading {rec.Value} with {rec.RequestId}");
                    Log.Info($"Recorded temperature reading {rec.Value} with {rec.RequestId}");
                    _lastTemperatureReading = rec.Value;
                    Sender.Tell(new TemperatureRecorded(rec.RequestId));
                    break;
                case ReadTemperature read:
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