using Akka.Actor;
using Akka.Pattern;
using Akka.TestKit.TestActors;
using Akka.TestKit.VsTest;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.concepts.supervision.whatLifecycleMonitoringMeans
{
    public class Class1 : TestKit
    {
        public Class1()
        {
            Props childProps = Props.Create<EchoActor>();
            Props supervisor = BackoffSupervisor.Props(
                Backoff.OnStop(
                    childProps,
                    "myEcho",
                    TimeSpan.FromSeconds(3),
                    TimeSpan.FromSeconds(30),
                    randomFactor: 0.2));

            Sys.ActorOf(supervisor, "echoSupervisor");

        }
    }
}
