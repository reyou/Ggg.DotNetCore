namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices
{
    public sealed class Temperature : ITemperatureReading
    {
        public Temperature(double value)
        {
            Value = value;
        }

        public double Value { get; }
    }
}