using System;

namespace GggAppDocs
{
    // https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio
    class HelloWorldApplication
    {
        public static void Run()
        {
            Console.WriteLine("\nWhat is your name? ");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");
            Console.Write("\nPress any key to exit...");
            Console.ReadKey(true);
        }
    }
}
