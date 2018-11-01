using Akka.Actor;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2
{
    [TestClass]
    public class DeviceTests : TestKit
    {
        [TestMethod]
        public void Tell()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            IActorRef actor = Sys.ActorOf(Device.Props("group", "device"));
            MainDevice.ReadTemperature readMessage = new MainDevice.ReadTemperature()
            {
                RequestId = Guid.NewGuid().GetHashCode()
            };
            actor.Tell(readMessage);
            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}
