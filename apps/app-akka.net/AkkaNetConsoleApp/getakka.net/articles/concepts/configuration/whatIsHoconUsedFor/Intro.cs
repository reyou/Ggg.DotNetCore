using Akka.Actor;
using Akka.Configuration;

namespace AkkaNetConsoleApp.getakka.net.articles.concepts.configuration.whatIsHoconUsedFor
{
    /// <summary>
    /// https://getakka.net/articles/concepts/configuration.html#deployment-whats-that
    /// </summary>
    public class Intro
    {
        public Intro()
        {
            Config config = ConfigurationFactory.ParseString(@"
akka.remote.dot-netty.tcp {
    transport-class = ""Akka.Remote.Transport.DotNetty.DotNettyTransport, Akka.Remote""
    transport-protocol = tcp
    port = 8091
    hostname = ""127.0.0.1""
}");

            ActorSystem system = ActorSystem.Create("MyActorSystem", config);

        }
    }
}
