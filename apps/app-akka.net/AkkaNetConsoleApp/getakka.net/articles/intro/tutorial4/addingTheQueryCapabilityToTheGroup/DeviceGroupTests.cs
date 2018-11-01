using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.addingTheQueryCapabilityToTheGroup
{
    [TestClass]
    public class DeviceGroupTests : TestKit
    {
        [TestMethod]
        public void DeviceGroup_actor_must_be_able_to_collect_temperatures_from_all_active_devices()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            TestProbe probe = CreateTestProbe();
            IActorRef groupActor = Sys.ActorOf(DeviceGroup.Props("group"));

            groupActor.Tell(new RequestTrackDevice("group", "device1"), probe.Ref);
            // probe.ExpectMsg<DeviceRegistered>();
            IActorRef deviceActor1 = probe.LastSender;

            groupActor.Tell(new RequestTrackDevice("group", "device2"), probe.Ref);
            // probe.ExpectMsg<DeviceRegistered>();
            IActorRef deviceActor2 = probe.LastSender;

            groupActor.Tell(new RequestTrackDevice("group", "device3"), probe.Ref);
            // probe.ExpectMsg<DeviceRegistered>();
            IActorRef deviceActor3 = probe.LastSender;

            // Check that the device actors are working
            deviceActor1.Tell(new RecordTemperature(requestId: 0, value: 1.0), probe.Ref);
            // probe.ExpectMsg<TemperatureRecorded>(s => s.RequestId == 0);
            deviceActor2.Tell(new RecordTemperature(requestId: 1, value: 2.0), probe.Ref);
            // probe.ExpectMsg<TemperatureRecorded>(s => s.RequestId == 1);
            // No temperature for device3

            groupActor.Tell(new RequestAllTemperatures(0), probe.Ref);
            //probe.ExpectMsg<RespondAllTemperatures>(msg =>
            //    msg.Temperatures["device1"].AsInstanceOf<Temperature>().Value == 1.0 &&
            //    msg.Temperatures["device2"].AsInstanceOf<Temperature>().Value == 2.0 &&
            //    msg.Temperatures["device3"] is TemperatureNotAvailable &&
            //    msg.RequestId == 0);

            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

    }
}
