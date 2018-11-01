using AkkaNetConsoleApp.TestUtilitiesNs;

// ReSharper disable once CheckNamespace
namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.write
{
    public sealed class TemperatureRecorded
    {
        public long RequestId { get; }
        public TemperatureRecorded(long requestId)
        {
            TestUtilities.WriteLine($"TemperatureRecorded.Constructor() requestId: {requestId}");
            RequestId = requestId;
        }
    }
}