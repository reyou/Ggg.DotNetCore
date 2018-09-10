using System;
using System.Threading.Tasks;

namespace fundamentalsProject
{
    public class MyDependency
    {
        public MyDependency()
        {
        }

        public Task WriteMessage(string message)
        {
            Console.WriteLine(
                $"MyDependency.WriteMessage called. Message: {message}");

            return Task.FromResult(0);
        }
    }
}
