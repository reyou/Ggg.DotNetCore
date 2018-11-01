using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

// ReSharper disable once CheckNamespace
namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial2.write
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-2.html#the-write-protocol
    /// </summary>
    [TestClass]
    public class DeviceTests : TestKit
    {
        [TestMethod]
        public void Tell()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            IActorRef deviceActor = Sys.ActorOf(Device.Props("group", "device"));
            RecordTemperature temperatureRecorded = new RecordTemperature(111, 222);
            ReadTemperature respondTemperature = new ReadTemperature(333);
            deviceActor.Tell(temperatureRecorded);
            deviceActor.Tell(respondTemperature);
            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        /// <summary>
        /// Could not load file or assembly 'Microsoft.VisualStudio.QualityTools.UnitTestFramework, Version=10.0.0.0
        /// </summary>
        [TestMethod]
        public void Tell2()
        {
            TestProbe probe = CreateTestProbe();
            IActorRef deviceActor = Sys.ActorOf(Device.Props("group", "device"));
            deviceActor.Tell(new RecordTemperature(requestId: 1, value: 24.0), probe.Ref);
            probe.ExpectMsg<TemperatureRecorded>(s => s.RequestId == 1);
            deviceActor.Tell(new ReadTemperature(requestId: 2), probe.Ref);
            RespondTemperature response1 = probe.ExpectMsg<RespondTemperature>();
            Assert.AreEqual(2, response1.RequestId);
            Assert.AreEqual(24.0, response1.Value);
            deviceActor.Tell(new RecordTemperature(requestId: 3, value: 55.0), probe.Ref);
            probe.ExpectMsg<TemperatureRecorded>(s => s.RequestId == 3);
            deviceActor.Tell(new ReadTemperature(requestId: 4), probe.Ref);
            RespondTemperature response2 = probe.ExpectMsg<RespondTemperature>();
            Assert.AreEqual(4, response2.RequestId);
            Assert.AreEqual(55.0, response2.Value);
        }
    }
}
