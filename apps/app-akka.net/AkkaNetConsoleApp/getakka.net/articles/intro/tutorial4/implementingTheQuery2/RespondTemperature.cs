using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.implementingTheQuery2
{
    public sealed class RespondTemperature
    {
        public RespondTemperature(long requestId, double? value)
        {
            TestUtilities.WriteLine($"RespondTemperature.Constructor() requestId: {requestId} value: {value}");
            RequestId = requestId;
            Value = value;
        }

        public long RequestId { get; }
        public double? Value { get; }
    }
}