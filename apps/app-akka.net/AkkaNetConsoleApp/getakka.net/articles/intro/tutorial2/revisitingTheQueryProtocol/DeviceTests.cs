using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.revisitingTheQueryProtocol
{
    [TestClass]
    public class DeviceTests : TestKit
    {
        [TestMethod]
        public void Tell()
        {
            MainDevice.ReadTemperature readMessage = new MainDevice.ReadTemperature
            {
                RequestId = Guid.NewGuid().GetHashCode()
            };
            TestUtilities.WriteLine("DeviceTests Begin");
            Props props = Device.Props("group", "device");
            IActorRef actor = Sys.ActorOf(props);
            // "actor: [akka://test/user/$a#1749946214]" ThreadId: 3
            TestUtilities.WriteLine("actor: " + actor);
            actor.Tell(readMessage);
            TestUtilities.WriteLine("DeviceTests End");
            TestUtilities.Sleep(2);
        }
    }
}
