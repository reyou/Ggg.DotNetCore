namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices
{
    public sealed class TemperatureNotAvailable : ITemperatureReading
    {
        public static TemperatureNotAvailable Instance { get; } = new TemperatureNotAvailable();
        private TemperatureNotAvailable() { }
    }
}