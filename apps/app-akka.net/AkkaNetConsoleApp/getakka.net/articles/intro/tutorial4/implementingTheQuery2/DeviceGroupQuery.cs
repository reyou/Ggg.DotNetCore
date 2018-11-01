using Akka.Actor;
using Akka.Event;
using AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.queryingAGroupOfDevices;
using AkkaNetConsoleApp.TestUtilitiesNs;
using System;
using System.Collections.Generic;

namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.implementingTheQuery2
{
    public class DeviceGroupQuery : UntypedActor
    {
        // ReSharper disable once InconsistentNaming
        private readonly ICancelable queryTimeoutTimer;
        protected ILoggingAdapter Log { get; } = Context.GetLogger();
        public Dictionary<IActorRef, string> ActorToDeviceId { get; }
        public long RequestId { get; }
        public IActorRef Requester { get; }
        public TimeSpan Timeout { get; }

        public DeviceGroupQuery(Dictionary<IActorRef, string> actorToDeviceId, long requestId, IActorRef requester, TimeSpan timeout)
        {
            ActorToDeviceId = actorToDeviceId;
            RequestId = requestId;
            Requester = requester;
            Timeout = timeout;
            // Schedules to send a message once after a specified period of time.
            queryTimeoutTimer = Context.System.Scheduler.ScheduleTellOnceCancelable(timeout, Self, CollectionTimeout.Instance, Self);
            UntypedReceive waitingForReplies = WaitingForReplies(new Dictionary<string, ITemperatureReading>(),
                new HashSet<IActorRef>(ActorToDeviceId.Keys));
            // Changes the actor's behavior and replaces the current receive handler with the specified handler.
            Become(waitingForReplies);
        }

        public UntypedReceive WaitingForReplies(Dictionary<string, ITemperatureReading> repliesSoFar, HashSet<IActorRef> stillWaiting)
        {
            void ForReplies(object message)
            {
                TestUtilities.WriteLine($"DeviceGroupQuery.WaitingForReplies() Requester: {Requester}");
                TestUtilities.WriteLine($"DeviceGroupQuery.WaitingForReplies() message: {message}");
                switch (message)
                {
                    case RespondTemperature response when response.RequestId == 0:
                        IActorRef deviceActor = Sender;
                        ITemperatureReading reading;
                        if (response.Value.HasValue)
                        {
                            TestUtilities.WriteLine($"DeviceGroupQuery.WaitingForReplies() response.Value.HasValue: {response.Value}");
                            reading = new Temperature(response.Value.Value);
                        }
                        else
                        {
                            TestUtilities.WriteLine($"DeviceGroupQuery.WaitingForReplies() TemperatureNotAvailable.Instance");
                            reading = TemperatureNotAvailable.Instance;
                        }

                        ReceivedResponse(deviceActor, reading, stillWaiting, repliesSoFar);
                        break;
                    case Terminated t:
                        ReceivedResponse(t.ActorRef, DeviceNotAvailable.Instance, stillWaiting, repliesSoFar);
                        break;
                    case CollectionTimeout _:
                        Dictionary<string, ITemperatureReading> replies = new Dictionary<string, ITemperatureReading>(repliesSoFar);
                        foreach (IActorRef actor in stillWaiting)
                        {
                            string deviceId = ActorToDeviceId[actor];
                            replies.Add(deviceId, DeviceTimedOut.Instance);
                        }

                        Requester.Tell(new RespondAllTemperatures(RequestId, replies));
                        Context.Stop(Self);
                        break;
                }
            }

            return ForReplies;
        }

        private void ReceivedResponse(IActorRef deviceActor, ITemperatureReading reading, HashSet<IActorRef> stillWaiting, Dictionary<string, ITemperatureReading> repliesSoFar)
        {
            TestUtilities.WriteLine($"DeviceGroupQuery.ReceivedResponse() Requester: {Requester}");
            TestUtilities.WriteLine($"DeviceGroupQuery.ReceivedResponse() deviceActor: {deviceActor}");
            // Stops monitoring the subject for termination
            Context.Unwatch(deviceActor);
            string deviceId = ActorToDeviceId[deviceActor];
            stillWaiting.Remove(deviceActor);

            repliesSoFar.Add(deviceId, reading);
            TestUtilities.WriteLine($"DeviceGroupQuery.ReceivedResponse() stillWaiting.Count: {stillWaiting.Count}");
            if (stillWaiting.Count == 0)
            {
                Requester.Tell(new RespondAllTemperatures(RequestId, repliesSoFar));
                Context.Stop(Self);
            }
            else
            {
                UntypedReceive waitingForReplies = WaitingForReplies(repliesSoFar, stillWaiting);
                Context.Become(waitingForReplies);
            }
        }

        protected override void PreStart()
        {
            foreach (IActorRef deviceActor in ActorToDeviceId.Keys)
            {
                Context.Watch(deviceActor);
                deviceActor.Tell(new ReadTemperature(0));
            }
        }

        protected override void PostStop()
        {
            TestUtilities.WriteLine($"DeviceGroupQuery.PostStop() queryTimeoutTimer.Cancel();");
            // This message is delivered to the Actor​Publisher<T> actor when the
            // stream subscriber cancels the subscription.
            queryTimeoutTimer.Cancel();
        }

        protected override void OnReceive(object message)
        {

        }

        public static Props Props(Dictionary<IActorRef, string> actorToDeviceId, long requestId, IActorRef requester, TimeSpan timeout)
        {
            Props props = Akka.Actor.Props.Create(() => new DeviceGroupQuery(actorToDeviceId, requestId, requester, timeout));
            return props;
        }
    }
}
