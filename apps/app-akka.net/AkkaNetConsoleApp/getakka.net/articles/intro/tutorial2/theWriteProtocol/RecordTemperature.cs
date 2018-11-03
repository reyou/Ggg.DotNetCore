


namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.theWriteProtocol
{
    public sealed class RecordTemperature
    {
        public long RequestId { get; }
        public double Value { get; }
        public RecordTemperature(long requestId, double value)
        {
            RequestId = requestId;
            Value = value;
        }
    }
}
