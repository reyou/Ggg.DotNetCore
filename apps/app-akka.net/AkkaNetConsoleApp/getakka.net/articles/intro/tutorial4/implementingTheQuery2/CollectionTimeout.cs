namespace AkkaNetConsoleApp.getakka.net.articles.intro.tutorial4.implementingTheQuery2
{
    public sealed class CollectionTimeout
    {
        public static CollectionTimeout Instance { get; } = new CollectionTimeout();
        private CollectionTimeout() { }
    }

}