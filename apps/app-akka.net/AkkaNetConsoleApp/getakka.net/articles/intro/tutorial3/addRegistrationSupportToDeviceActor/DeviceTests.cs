using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.theRegistrationProtocol;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial3.addRegistrationSupportToDeviceActor
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-3.html#add-registration-support-to-device-actor
    /// </summary>
    [TestClass]
    public class DeviceTests : TestKit
    {
        [TestMethod]
        public void Tell()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            IActorRef deviceActor = Sys.ActorOf(Device.Props("group-device", "device-device"));
            RequestTrackDevice requestTrackDevice = new RequestTrackDevice("group-device", "device-device");
            RequestTrackDevice requestTrackDevice2 = new RequestTrackDevice("groupId-1", "deviceId-1");
            RecordTemperature recordTemperature = new RecordTemperature(111, 222);
            ReadTemperature readTemperature = new ReadTemperature(333);
            deviceActor.Tell(requestTrackDevice);
            deviceActor.Tell(requestTrackDevice2);
            deviceActor.Tell(recordTemperature);
            deviceActor.Tell(readTemperature);
            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void Device_actor_must_reply_to_registration_requests()
        {
            TestProbe probe = CreateTestProbe();
            IActorRef deviceActor = Sys.ActorOf(Device.Props("group", "device"));
            deviceActor.Tell(new RequestTrackDevice("group", "device"), probe.Ref);
            probe.ExpectMsg<DeviceRegistered>();
            Assert.AreSame(deviceActor, probe.LastSender);
        }
        [TestMethod]
        public void Device_actor_must_ignore_wrong_registration_requests()
        {
            TestProbe probe = CreateTestProbe();
            IActorRef deviceActor = Sys.ActorOf(Device.Props("group", "device"));
            deviceActor.Tell(new RequestTrackDevice("wrongGroup", "device"), probe.Ref);
            probe.ExpectNoMsg(TimeSpan.FromMilliseconds(500));
            deviceActor.Tell(new RequestTrackDevice("group", "Wrongdevice"), probe.Ref);
            probe.ExpectNoMsg(TimeSpan.FromMilliseconds(500));
        }

    }
}
