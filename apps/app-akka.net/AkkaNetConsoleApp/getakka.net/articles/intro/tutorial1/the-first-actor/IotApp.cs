using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
{
    public class IotApp
    {
        public static void Init()
        {
            TestUtilities.WriteLine("IotApp Init");
            using (ActorSystem system = ActorSystem.Create("iot-system"))
            {
                // Create top level supervisor
                IActorRef supervisor = system.ActorOf(Props.Create<IotSupervisor>(), "iot-supervisor");
                TestUtilities.WriteLine("IotApp Init supervisor: " + supervisor);
                // Exit the system after ENTER is pressed
                // Console.ReadLine();

            }
        }
    }
}