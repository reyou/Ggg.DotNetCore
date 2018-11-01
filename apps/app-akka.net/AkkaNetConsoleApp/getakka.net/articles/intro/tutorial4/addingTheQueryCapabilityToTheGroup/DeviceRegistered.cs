namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.addingTheQueryCapabilityToTheGroup
{
    public sealed class DeviceRegistered
    {
        public static DeviceRegistered Instance { get; } = new DeviceRegistered();
        private DeviceRegistered() { }
    }
}