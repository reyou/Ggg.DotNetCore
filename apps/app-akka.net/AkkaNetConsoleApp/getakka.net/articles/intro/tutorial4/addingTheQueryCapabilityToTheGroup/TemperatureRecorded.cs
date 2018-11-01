using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.addingTheQueryCapabilityToTheGroup
{
    public sealed class TemperatureRecorded
    {
        public TemperatureRecorded(long requestId)
        {
            TestUtilities.WriteLine($"TemperatureRecorded.Constructor() requestId: {requestId}");
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}