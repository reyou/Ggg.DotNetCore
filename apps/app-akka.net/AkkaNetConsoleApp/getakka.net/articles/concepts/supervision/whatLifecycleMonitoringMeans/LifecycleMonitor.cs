using Akka.Actor;
using Akka.Pattern;
using Akka.TestKit.TestActors;
using Akka.TestKit.VsTest;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;

namespace AkkaNetConsoleApp.getakka.net.articles.concepts.supervision.whatLifecycleMonitoringMeans
{
    [SuppressMessage("ReSharper", "ArgumentsStyleOther")]
    public class LifecycleMonitor : TestKit
    {
        public void OnStopExample()
        {
            /*The following C# snippet shows how to create a back off supervisor which
             will start the given echo actor after it has stopped because of a failure, 
             in increasing intervals of 3, 6, 12, 24 and finally 30 seconds:*/
            Props childProps = Props.Create<EchoActor>();
            BackoffOptions backoffOptions = Backoff.OnStop(
                childProps: childProps,
                childName: "myEcho",
                minBackoff: TimeSpan.FromSeconds(3),
                maxBackoff: TimeSpan.FromSeconds(30),
                randomFactor: 0.2);
            Props supervisor = BackoffSupervisor.Props(backoffOptions);
            IActorRef actorRef = Sys.ActorOf(supervisor, "echoSupervisor");
        }
        public void OnStopWithDefaultStoppingStrategyExample()
        {
            /*The Akka.Pattern.BackoffOptions can be used to customize the behavior of
             the back-off supervisor actor, below are some examples:*/
            Props childProps = Props.Create<EchoActor>();
            BackoffOptions backoffOptions = Backoff.OnStop(
                    childProps: childProps,
                    childName: "myEcho",
                    minBackoff: TimeSpan.FromSeconds(3),
                    maxBackoff: TimeSpan.FromSeconds(30),
                    randomFactor: 0.2)
                .WithManualReset() // the child must send BackoffSupervisor.Reset to its parent
                .WithDefaultStoppingStrategy();
            Props supervisor = BackoffSupervisor.Props(backoffOptions); // Stop at any Exception thrown

            IActorRef actorRef = Sys.ActorOf(supervisor, "echoSupervisor");
        }

        public void OnStopWithSupervisorStrategyExample()
        {
            Props childProps = Props.Create<EchoActor>();
            BackoffOptions backoffOptions = Backoff.OnStop(
                    childProps,
                    childName: "myEcho",
                    minBackoff: TimeSpan.FromSeconds(3),
                    maxBackoff: TimeSpan.FromSeconds(30),
                    randomFactor: 0.2)
                .WithAutoReset(TimeSpan.FromSeconds(10))
                .WithSupervisorStrategy(new OneForOneStrategy(exception =>
                {
                    if (exception is HttpRequestException)
                        return Directive.Restart;
                    return Directive.Escalate;
                }));
            Props supervisor = BackoffSupervisor.Props(backoffOptions);
            IActorRef actorRef = Sys.ActorOf(supervisor, "echoSupervisor");
        }

        public void OnFailureExample()
        {
            /*The following C# snippet shows how to create a back off supervisor which will start the
             given echo actor after it has crashed because of some exception, 
             in increasing intervals of 3, 6, 12, 24 and finally 30 seconds::*/
            Props childProps = Props.Create<EchoActor>();
            BackoffOptions backoffOptions = Backoff.OnFailure(
                childProps: childProps,
                childName: "myEcho",
                minBackoff: TimeSpan.FromSeconds(3),
                maxBackoff: TimeSpan.FromSeconds(30),
                randomFactor: 0.2);
            Props supervisor = BackoffSupervisor.Props(backoffOptions);
            IActorRef actorRef = Sys.ActorOf(supervisor, "echoSupervisor");
        }
    }
}
