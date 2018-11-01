using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2
{
    public class Device : UntypedActor
    {
        private double? _lastTemperatureReading;
        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        protected string GroupId { get; }
        protected string DeviceId { get; }
        protected override void PreStart()
        {
            TestUtilities.Info($"Device actor {GroupId}-{DeviceId} started");
            Log.Info($"Device actor {GroupId}-{DeviceId} started");
        }

        protected override void PostStop()
        {
            TestUtilities.Info($"Device actor {GroupId}-{DeviceId} stopped");
            Log.Info($"Device actor {GroupId}-{DeviceId} stopped");
        }

        public Device(string groupId, string deviceId)
        {
            TestUtilities.WriteLine($"Device Constructor. groupId: {groupId}, deviceId: {deviceId}");
            GroupId = groupId;
            DeviceId = deviceId;
        }
        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("Device OnReceive: " + message);
            switch (message)
            {
                case MainDevice.ReadTemperature read:
                    Sender.Tell(new revisiting.RespondTemperature(read.RequestId, _lastTemperatureReading));
                    break;
            }
        }

        public static Props Props(string groupId, string deviceId)
        {
            TestUtilities.WriteLine($"Device Props. groupId: {groupId}, deviceId: {deviceId}");
            return Akka.Actor.Props.Create(() => new Device(groupId, deviceId));
        }
    }
}
