namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.implementingTheQuery2
{
    public sealed class ReadTemperature
    {
        public ReadTemperature(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}