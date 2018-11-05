using System.Collections.Generic;

namespace AkkaNetConsoleApp.getakka.net.articles.actors.receiveActorApi.messagesAndImmutability
{
    /// <summary>
    /// Messages can be any kind of object but have to be immutable.
    /// Akka can’t enforce immutability (yet) so this has to be by convention.
    /// https://getakka.net/articles/actors/receive-actor-api.html#messages-and-immutability
    /// </summary>
    public class ImmutableMessage
    {
        public int SequenceNumber { get; }
        public IReadOnlyCollection<string> Values { get; }
        public ImmutableMessage(int sequenceNumber, List<string> values)
        {
            SequenceNumber = sequenceNumber;
            Values = values.AsReadOnly();
        }
    }
}
