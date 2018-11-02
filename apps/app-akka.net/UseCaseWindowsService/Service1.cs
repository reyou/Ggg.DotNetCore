using Akka.Actor;
using System.ServiceProcess;
using Topshelf;

namespace UseCaseWindowsService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<MyActorService>(s =>
                {
                    s.ConstructUsing(n => new MyActorService());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                    //continue and restart directives are also available
                });
                x.RunAsLocalSystem();
                x.UseAssemblyInfoForServiceInfo();
            });
        }

        /// <summary>
        /// This class acts as an interface between your application and TopShelf
        /// </summary>
        public class MyActorService
        {
            private ActorSystem mySystem;

            public void Start()
            {
                //this is where you setup your actor system and other things
                mySystem = ActorSystem.Create("MySystem");
            }

            public async void Stop()
            {
                //this is where you stop your actor system
                await mySystem.Terminate();
            }
        }
        protected override void OnStop()
        {
        }
    }
}
