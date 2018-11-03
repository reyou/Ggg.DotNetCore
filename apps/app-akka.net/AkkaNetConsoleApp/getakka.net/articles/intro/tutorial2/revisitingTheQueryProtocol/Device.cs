using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.revisitingTheQueryProtocol
{
    public class Device : UntypedActor
    {
        private double? _lastTemperatureReading;
        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        protected string GroupId { get; }
        protected string DeviceId { get; }
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
        protected override void OnReceive(object message)
        {
            // "Device.OnReceive() Self [akka://test/user/$a#1749946214]" ThreadId: 11
            TestUtilities.WriteLine("Device.OnReceive() Self " + Self);

            // "Device.OnReceive() Sender [akka://test/system/testActor1#1651234693]" ThreadId: 11
            TestUtilities.WriteLine("Device.OnReceive() Sender " + Sender);

            TestUtilities.WriteLine("Device.OnReceive() " + message);

            switch (message)
            {
                case MainDevice.ReadTemperature read:
                    _lastTemperatureReading = 123;
                    RespondTemperature respondTemperature = new RespondTemperature(read.RequestId, _lastTemperatureReading);
                    Sender.Tell(respondTemperature);
                    TestUtilities.WriteLine("Device.OnReceive() Sender.Tell(respondTemperature);");
                    break;
            }
        }

        public static Props Props(string groupId, string deviceId)
        {
            TestUtilities.WriteLine($"Device.Props() groupId: {groupId}, deviceId: {deviceId}");
            Props props = Akka.Actor.Props.Create(() => new Device(groupId, deviceId));
            return props;
        }
    }
}
