using System;
using System.Threading.Tasks;

namespace fundamentalsProject.middleware.extensibility
{
    public class AppDbContext
    {
        public void Add(Request request)
        {
            Console.WriteLine("AppDbContext.Add");
        }

        public Task SaveChangesAsync()
        {
            Console.WriteLine("AppDbContext.SaveChangesAsync");
            return Task.FromResult(1);
        }
    }
}