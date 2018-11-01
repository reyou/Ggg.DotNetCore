namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices
{
    public sealed class RequestAllTemperatures
    {
        public RequestAllTemperatures(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}
