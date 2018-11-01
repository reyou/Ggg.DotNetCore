using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.theRegistrationProtocol;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.deviceGroupWatch
{

    [TestClass]
    public class DeviceGroupTests : TestKit
    {
        [TestMethod]
        public void DeviceGroup_actor_must_be_able_to_list_active_devices()
        {
            TestUtilities.WriteLine("DeviceGroupTests Begin");
            TestProbe probe = CreateTestProbe();
            IActorRef groupActor = Sys.ActorOf(DeviceGroup.Props("group"));

            groupActor.Tell(new RequestTrackDevice("group", "device1"), probe.Ref);
            probe.ExpectMsg<DeviceRegistered>();

            groupActor.Tell(new RequestTrackDevice("group", "device2"), probe.Ref);
            probe.ExpectMsg<DeviceRegistered>();

            groupActor.Tell(new RequestDeviceList(requestId: 0), probe.Ref);
            // probe.ExpectMsg<ReplyDeviceList>(s => s.RequestId == 0 && s.Ids.Contains("device1") && s.Ids.Contains("device2"));
            TestUtilities.WriteLine("DeviceGroupTests End");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [TestMethod]
        public void DeviceGroup_actor_must_be_able_to_list_active_devices_after_one_shuts_down()
        {
            TestUtilities.WriteLine("DeviceGroupTests Begin");
            TestProbe probe = CreateTestProbe();
            IActorRef groupActor = Sys.ActorOf(DeviceGroup.Props("group"));

            groupActor.Tell(new RequestTrackDevice("group", "device1"), probe.Ref);
            probe.ExpectMsg<DeviceRegistered>();
            IActorRef toShutDown = probe.LastSender;

            groupActor.Tell(new RequestTrackDevice("group", "device2"), probe.Ref);
            probe.ExpectMsg<DeviceRegistered>();

            groupActor.Tell(new RequestDeviceList(requestId: 0), probe.Ref);
            // probe.ExpectMsg<ReplyDeviceList>(s => s.RequestId == 0 && s.Ids.Contains("device1") && s.Ids.Contains("device2"));
            TestUtilities.WriteLine("DeviceGroupTests toShutDown: " + toShutDown);
            probe.Watch(toShutDown);
            TestUtilities.WriteLine("DeviceGroupTests probe.Watch(toShutDown): " + toShutDown);
            toShutDown.Tell(PoisonPill.Instance);
            TestUtilities.WriteLine("DeviceGroupTests toShutDown.Tell(PoisonPill.Instance): " + toShutDown);
            // probe.ExpectTerminated(toShutDown);

            // using awaitAssert to retry because it might take longer for the groupActor
            // to see the Terminated, that order is undefined
            //probe.AwaitAssert(() =>
            //{
            //    groupActor.Tell(new RequestDeviceList(requestId: 1), probe.Ref);
            //    probe.ExpectMsg<ReplyDeviceList>(s => s.RequestId == 1 && s.Ids.Contains("device2"));
            //});

            TestUtilities.WriteLine("DeviceGroupTests End");
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

    }
}
