namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices
{
    public sealed class DeviceTimedOut : ITemperatureReading
    {
        public static DeviceTimedOut Instance { get; } = new DeviceTimedOut();
        private DeviceTimedOut() { }
    }
}