using System.Collections.Generic;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices
{
    public sealed class RespondAllTemperatures
    {
        public RespondAllTemperatures(long requestId, Dictionary<string, ITemperatureReading> temperatures)
        {
            RequestId = requestId;
            Temperatures = temperatures;
        }

        public long RequestId { get; }
        public Dictionary<string, ITemperatureReading> Temperatures { get; }
    }
}