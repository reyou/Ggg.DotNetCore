using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.addRegistrationSupportToDeviceActor;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.theRegistrationProtocol;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.deviceGroup
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-3.html#device-group
    /// </summary>
    [TestClass]
    public class DeviceGroupTests : TestKit
    {
        [TestMethod]
        public void DeviceGroup_actor_must_be_able_to_register_a_device_actor()
        {
            TestUtilities.WriteLine("DeviceGroupTests Begin");
            TestProbe testProbe = CreateTestProbe();
            IActorRef testProbeRef = testProbe.Ref;
            // "testProbeRef: [akka://test/system/testActor2#1058686348]" ThreadId: 3
            TestUtilities.WriteLine("testProbeRef: " + testProbeRef);
            //
            Props props = DeviceGroup.Props("group");
            IActorRef deviceGroupActor = Sys.ActorOf(props);
            // "deviceGroupActor: [akka://test/user/$a#1567413838]" ThreadId: 3
            TestUtilities.WriteLine("deviceGroupActor: " + deviceGroupActor);
            //
            deviceGroupActor.Tell(new RequestTrackDevice("group", "device1"), testProbe.Ref);
            testProbe.ExpectMsg<DeviceRegistered>();
            IActorRef deviceActor1 = testProbe.LastSender;
            //
            deviceGroupActor.Tell(new RequestTrackDevice("group", "device2"), testProbe.Ref);
            testProbe.ExpectMsg<DeviceRegistered>();
            IActorRef deviceActor2 = testProbe.LastSender;
            Assert.AreNotSame(deviceActor1, deviceActor2);
            // Check that the device actors are working
            deviceActor1.Tell(new RecordTemperature(requestId: 0, value: 1.0), testProbe.Ref);
            // probe.ExpectMsg<TemperatureRecorded>(s => s.RequestId == 0);
            deviceActor2.Tell(new RecordTemperature(requestId: 1, value: 2.0), testProbe.Ref);
            //probe.ExpectMsg<TemperatureRecorded>(s => s.RequestId == 1);
            TestUtilities.WriteLine("DeviceGroupTests End");
            TestUtilities.Sleep(2);
        }

        [TestMethod]
        public void DeviceGroup_actor_must_ignore_requests_for_wrong_groupId()
        {
            TestUtilities.WriteLine("DeviceGroupTests Begin");
            TestProbe probe = CreateTestProbe();
            IActorRef groupActor = Sys.ActorOf(DeviceGroup.Props("group"));
            groupActor.Tell(new RequestTrackDevice("wrongGroup", "device1"), probe.Ref);
            groupActor.Tell(new Guid(), probe.Ref);
            probe.ExpectNoMsg(TimeSpan.FromMilliseconds(500));
            TestUtilities.WriteLine("DeviceGroupTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void DeviceGroup_actor_must_return_same_actor_for_same_deviceId()
        {
            TestUtilities.WriteLine("DeviceGroupTests Begin");
            TestProbe probe = CreateTestProbe();
            IActorRef groupActor = Sys.ActorOf(DeviceGroup.Props("group"));

            groupActor.Tell(new RequestTrackDevice("group", "device1"), probe.Ref);
            probe.ExpectMsg<DeviceRegistered>();
            IActorRef deviceActor1 = probe.LastSender;

            groupActor.Tell(new RequestTrackDevice("group", "device1"), probe.Ref);
            probe.ExpectMsg<DeviceRegistered>();
            IActorRef deviceActor2 = probe.LastSender;

            Assert.AreSame(deviceActor1, deviceActor2);
            TestUtilities.WriteLine("DeviceGroupTests End");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }
}
