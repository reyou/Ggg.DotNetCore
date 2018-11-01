using System.Collections.Generic;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.deviceGroupWatch
{
    public sealed class ReplyDeviceList
    {
        public ReplyDeviceList(long requestId, ISet<string> ids)
        {
            RequestId = requestId;
            Ids = ids;
        }

        public long RequestId { get; }
        public ISet<string> Ids { get; }
    }
}