
namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.theWriteProtocol
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