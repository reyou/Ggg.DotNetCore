using System.Threading.Tasks;

namespace fundamentalsProject.dependencyInjection
{
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
}