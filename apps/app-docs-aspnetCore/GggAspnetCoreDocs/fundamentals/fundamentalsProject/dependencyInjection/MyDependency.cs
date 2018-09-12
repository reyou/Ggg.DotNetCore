using System;
using System.Threading.Tasks;

namespace fundamentalsProject.dependencyInjection
{
    public class MyDependency : IMyDependency
    {
        public async Task WriteMessage(string message) => await Task.Run(() =>
        {
            Console.WriteLine("MyDependency.WriteMessage is running.");
        });
    }
}