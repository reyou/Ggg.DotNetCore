namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.theRegistrationProtocol
{
    public sealed class RequestTrackDevice
    {
        public string GroupId { get; }
        public string DeviceId { get; }
        public RequestTrackDevice(string groupId, string deviceId)
        {
            GroupId = groupId;
            DeviceId = deviceId;
        }
    }
}
