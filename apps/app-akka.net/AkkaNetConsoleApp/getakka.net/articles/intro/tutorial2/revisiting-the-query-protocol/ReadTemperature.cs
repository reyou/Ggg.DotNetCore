using AkkaNetConsoleApp.TestUtilitiesNs;

// ReSharper disable once CheckNamespace
namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.revisiting
{
    public sealed class ReadTemperature
    {
        public ReadTemperature(long requestId)
        {
            TestUtilities.WriteLine($"ReadTemperature Constructor(). requestId: {requestId}");
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
