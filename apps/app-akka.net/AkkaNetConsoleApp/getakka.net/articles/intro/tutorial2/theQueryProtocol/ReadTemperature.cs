namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2
{
    public sealed class ReadTemperature
    {
        public static ReadTemperature Instance { get; } = new ReadTemperature();
        private ReadTemperature() { }
    }
}
