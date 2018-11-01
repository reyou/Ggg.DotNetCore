namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices
{
    public sealed class DeviceNotAvailable : ITemperatureReading
    {
        public static DeviceNotAvailable Instance { get; } = new DeviceNotAvailable();
        private DeviceNotAvailable() { }
    }
}