namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.theQueryProtocol
{
    public sealed class RespondTemperature
    {
        public RespondTemperature(double? value)
        {
            Value = value;
        }

        public double? Value { get; }
    }
}