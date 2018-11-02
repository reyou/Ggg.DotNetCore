using Akka.Actor;
using Akka.Configuration;
using System;

namespace UseCaseConsoleApplication
{
    /// <summary>
    /// https://getakka.net/articles/intro/use-case-and-deployment-scenarios.html#console-application
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            //configure remoting for localhost:8081
            //var fluentConfig = FluentConfig.Begin()
            //    .StartRemotingOn("localhost", 8081)
            //    .Build();
            Config fluentConfig = Config.Empty;
            using (ActorSystem system = ActorSystem.Create("my-actor-server", fluentConfig))
            {
                //start two services
                IActorRef service1 = system.ActorOf<Service1>("service1");
                IActorRef service2 = system.ActorOf<Service2>("service2");
                Console.WriteLine("Application started.");
                Console.WriteLine("Press any key to close the application.");
                Console.ReadKey();
            }
        }
    }
}
