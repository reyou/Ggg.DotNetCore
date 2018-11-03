using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.theFirstActor
{
    public class IotApp
    {
        public static void Init()
        {
            TestUtilities.WriteLine("IotApp Init");
            using (ActorSystem system = ActorSystem.Create("iot-system"))
            {
                Props props = Props.Create<IotSupervisor>();
                IActorRef supervisor = system.ActorOf(props, "iot-supervisor");
                // "IotApp Init supervisor: [akka://iot-system/user/iot-supervisor#425694740]" ThreadId: 3
                TestUtilities.WriteLine("IotApp Init supervisor: " + supervisor);
            }
        }
    }
}