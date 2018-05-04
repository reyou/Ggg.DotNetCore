using Newtonsoft.Json;
using System;
using System.Net;

namespace Porting.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPosts();
            Console.ReadLine();
        }

        private static void GetPosts()
        {
            WebClient client = new WebClient();
            string address = "https://jsonplaceholder.typicode.com/posts";
            string downloadString = client.DownloadString(address);
            dynamic deserializeObject = JsonConvert.DeserializeObject<dynamic>(downloadString);
            foreach (dynamic item in deserializeObject)
            {
                Console.WriteLine("\nItem:");
                Console.WriteLine(item.id);
                Console.WriteLine(item.userId);
                Console.WriteLine(item.title);
                Console.WriteLine(item.body);
            }
        }
    }
}
