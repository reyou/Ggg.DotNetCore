using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.addRegistrationSupportToDeviceActor
{
    public sealed class RespondTemperature
    {
        public RespondTemperature(long requestId, double? value)
        {
            TestUtilities.WriteLine($"RespondTemperature.Constructor() requestId: {requestId}");
            RequestId = requestId;
            Value = value;
        }

        public long RequestId { get; }
        public double? Value { get; }
    }
}