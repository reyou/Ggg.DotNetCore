using AkkaNetConsoleApp.TestUtilitiesNs;

// ReSharper disable once CheckNamespace
namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.revisitingTheQueryProtocol
{
    public sealed class RespondTemperature
    {
        public RespondTemperature(long requestId, double? value)
        {
            TestUtilities.WriteLine($"RespondTemperature.Constructor() requestId: {requestId}, value: {value}");
            RequestId = requestId;
            Value = value;
        }

        public long RequestId { get; }
        public double? Value { get; }
    }
}