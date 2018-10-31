using System;
using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
{
    public class SupervisedActor : UntypedActor
    {
        protected override void PreStart()
        {
            TestUtilities.WriteLine("supervised actor started");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("supervised actor stopped");
        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case "fail":
                    TestUtilities.WriteLine("supervised actor fails now");
                    throw new Exception("I failed!");
            }
        }
    }
}