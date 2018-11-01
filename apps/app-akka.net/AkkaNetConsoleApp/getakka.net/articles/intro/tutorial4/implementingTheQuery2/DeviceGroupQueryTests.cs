using Akka.Actor;
using Akka.TestKit;
using Akka.TestKit.VsTest;
using AkkaNetConsoleApp.TestUtilitiesNs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.implementingTheQuery2
{
    /// <summary>
    /// https://getakka.net/articles/intro/tutorial-4.html#testing
    /// </summary>
    [TestClass]
    public class DeviceGroupQueryTests : TestKit
    {
        [TestMethod]
        public void DeviceGroupQuery_must_return_temperature_value_for_working_devices()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            TestProbe requester = CreateTestProbe();
            TestProbe device1 = CreateTestProbe();
            TestProbe device2 = CreateTestProbe();
            Dictionary<IActorRef, string> dictionary = new Dictionary<IActorRef, string>
            {
                [device1.Ref] = "device1",
                [device2.Ref] = "device2"
            };
            IActorRef queryActor = Sys.ActorOf(DeviceGroupQuery.Props(dictionary,
                1,
                requester.Ref,
                TimeSpan.FromSeconds(3)
            ));

            // device1.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);
            // device2.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);

            queryActor.Tell(new RespondTemperature(requestId: 0, value: 1.0), device1.Ref);
            queryActor.Tell(new RespondTemperature(requestId: 0, value: 2.0), device2.Ref);

            //requester.ExpectMsg<RespondAllTemperatures>(msg =>
            //    msg.Temperatures["device1"].AsInstanceOf<Temperature>().Value == 1.0 &&
            //    msg.Temperatures["device2"].AsInstanceOf<Temperature>().Value == 2.0 &&
            //    msg.RequestId == 1);

            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void DeviceGroupQuery_must_return_TemperatureNotAvailable_for_devices_with_no_readings()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            TestProbe requester = CreateTestProbe();

            TestProbe device1 = CreateTestProbe();
            TestProbe device2 = CreateTestProbe();
            Dictionary<IActorRef, string> dictionary = new Dictionary<IActorRef, string>
            {
                [device1.Ref] = "device1",
                [device2.Ref] = "device2"
            };
            Props props = DeviceGroupQuery.Props(dictionary, 1, requester.Ref, TimeSpan.FromSeconds(3));
            IActorRef queryActor = Sys.ActorOf(props);

            // device1.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);
            // device2.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);

            queryActor.Tell(new RespondTemperature(requestId: 0, value: null), device1.Ref);
            queryActor.Tell(new RespondTemperature(requestId: 0, value: 2.0), device2.Ref);

            //requester.ExpectMsg<RespondAllTemperatures>(msg =>
            //    msg.Temperatures["device1"] is TemperatureNotAvailable &&
            //    msg.Temperatures["device2"].AsInstanceOf<Temperature>().Value == 2.0 &&
            //    msg.RequestId == 1);
            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void DeviceGroupQuery_must_return_return_DeviceNotAvailable_if_device_stops_before_answering()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            TestProbe requester = CreateTestProbe();
            TestProbe device1 = CreateTestProbe();
            TestProbe device2 = CreateTestProbe();

            Dictionary<IActorRef, string> dictionary = new Dictionary<IActorRef, string>
            {
                [device1.Ref] = "device1",
                [device2.Ref] = "device2"
            };
            Props props = DeviceGroupQuery.Props(dictionary, 1, requester.Ref, TimeSpan.FromSeconds(3));
            IActorRef queryActor = Sys.ActorOf(props);

            // device1.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);
            // device2.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);
            TestUtilities.WriteLine("DeviceTests Start Sending Messages");
            RespondTemperature respondTemperature = new RespondTemperature(requestId: 0, value: 1.0);
            queryActor.Tell(respondTemperature, device2.Ref);
            device2.Tell(PoisonPill.Instance);

            //requester.ExpectMsg<RespondAllTemperatures>(msg => msg.Temperatures["device1"].AsInstanceOf<Temperature>().Value == 1.0 &&
            //    msg.Temperatures["device2"] is DeviceNotAvailable &&
            //    msg.RequestId == 1);
            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void DeviceGroupQuery_must_return_temperature_reading_even_if_device_stops_after_answering()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            TestProbe requester = CreateTestProbe();
            TestProbe device1 = CreateTestProbe();
            TestProbe device2 = CreateTestProbe();
            Dictionary<IActorRef, string> dictionary = new Dictionary<IActorRef, string>
            {
                [device1.Ref] = "device1",
                [device2.Ref] = "device2"
            };
            Props props = DeviceGroupQuery.Props(dictionary, 1, requester.Ref, TimeSpan.FromSeconds(3));
            IActorRef queryActor = Sys.ActorOf(props);

            //  device1.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);
            //  device2.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);

            queryActor.Tell(new RespondTemperature(requestId: 0, value: 1.0), device1.Ref);
            queryActor.Tell(new RespondTemperature(requestId: 0, value: 2.0), device2.Ref);
            device2.Tell(PoisonPill.Instance);

            //requester.ExpectMsg<RespondAllTemperatures>(msg =>
            //    msg.Temperatures["device1"].AsInstanceOf<Temperature>().Value == 1.0 &&
            //    msg.Temperatures["device2"].AsInstanceOf<Temperature>().Value == 2.0 &&
            //    msg.RequestId == 1);
            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [TestMethod]
        public void DeviceGroupQuery_must_return_DeviceTimedOut_if_device_does_not_answer_in_time()
        {
            TestUtilities.WriteLine("DeviceTests Begin");
            TestProbe requester = CreateTestProbe();
            TestProbe device1 = CreateTestProbe();
            TestProbe device2 = CreateTestProbe();
            Dictionary<IActorRef, string> dictionary = new Dictionary<IActorRef, string>
            {
                [device1.Ref] = "device1",
                [device2.Ref] = "device2"
            };
            Props props = DeviceGroupQuery.Props(dictionary, 1, requester.Ref, TimeSpan.FromSeconds(1));
            IActorRef queryActor = Sys.ActorOf(props);
            // device1.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);
            // device2.ExpectMsg<ReadTemperature>(read => read.RequestId == 0);

            queryActor.Tell(new RespondTemperature(requestId: 0, value: 1.0), device1.Ref);

            //requester.ExpectMsg<RespondAllTemperatures>(msg =>
            //    msg.Temperatures["device1"].AsInstanceOf<Temperature>().Value == 1.0 &&
            //    msg.Temperatures["device2"] is DeviceTimedOut &&
            //    msg.RequestId == 1);
            TestUtilities.WriteLine("DeviceTests End");
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }




    }
}
