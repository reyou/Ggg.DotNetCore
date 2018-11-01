using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.addRegistrationSupportToDeviceActor
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