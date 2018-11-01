using Akka.Actor;
using AkkaNetConsoleApp.TestUtilitiesNs;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial1
{
    public class SupervisedActor : UntypedActor
    {
        protected override void PreStart()
        {
            TestUtilities.WriteLine("SupervisedActor PreStart");
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine("SupervisedActor PostStop");
        }

        protected override void OnReceive(object message)
        {
            TestUtilities.WriteLine("SupervisedActor OnReceive");
            switch (message)
            {
                case "fail":
                    TestUtilities.WriteLine("SupervisedActor fails now");
                    throw new Exception("I failed!");
            }
        }
    }
}