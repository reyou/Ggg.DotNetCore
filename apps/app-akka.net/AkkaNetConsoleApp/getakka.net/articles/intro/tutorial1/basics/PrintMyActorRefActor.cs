using Akka.Actor;
using System;
using System.Diagnostics;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1.basics
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-1.html#structure-of-an-iactorref-and-paths-of-actors
    /// </summary>
    public class PrintMyActorRefActor : UntypedActor
    {
        protected override void OnReceive(object message)
        {
            if (Debugger.IsAttached) { Debugger.Break(); }
            switch (message)
            {
                case "printit":
                    IActorRef secondRef = Context.ActorOf(Props.Empty, "second-actor");
                    Console.WriteLine($"Second: {secondRef}");
                    Console.WriteLine($"ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                    break;
            }
        }
    }
}
