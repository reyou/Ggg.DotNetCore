namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.theRegistrationProtocol
{
    public sealed class DeviceRegistered
    {
        public static DeviceRegistered Instance { get; } = new DeviceRegistered();
        private DeviceRegistered() { }
    }
}