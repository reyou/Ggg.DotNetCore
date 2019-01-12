using System;
using System.Text.RegularExpressions;

namespace GggAppDocs.deploying.FrameworkDependentDeployment
{
    /// <summary>
    /// Framework-dependent deployment
    /// https://docs.microsoft.com/en-us/dotnet/core/deploying/deploy-with-cli
    /// dotnet publish -f netcoreapp1.1 -c Release
    /// </summary>
    public class ConsoleParser
    {
        public static void MainConsoleParser()
        {
            Console.WriteLine("Enter any text, followed by <Enter>:\n");
            String s = Console.ReadLine();
            ShowWords(s);
            Console.Write("\nPress any key to continue... ");
            Console.ReadKey();
        }

        private static void ShowWords(String s)
        {
            String pattern = @"\w+";
            var matches = Regex.Matches(s, pattern);
            if (matches.Count == 0)
            {
                Console.WriteLine("\nNo words were identified in your input.");
            }
            else
            {
                Console.WriteLine($"\nThere are {matches.Count} words in your string:");
                for (int ctr = 0; ctr < matches.Count; ctr++)
                {
                    Console.WriteLine($"   #{ctr,2}: '{matches[ctr].Value}' at position {matches[ctr].Index}");
                }
            }
        }
    }
}
