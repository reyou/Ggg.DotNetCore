namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.deviceGroupWatch
{
    public sealed class RequestDeviceList
    {
        public RequestDeviceList(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}