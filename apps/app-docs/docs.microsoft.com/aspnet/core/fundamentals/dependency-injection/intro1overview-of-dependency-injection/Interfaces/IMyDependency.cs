using System.Threading.Tasks;
using DependencyInjectionSample.Pages;

namespace DependencyInjectionSample.Interfaces
{
    #region snippet1
    /// <summary>
    /// <see cref="IndexModel"/>
    /// </summary>
    public interface IMyDependency
    {
        Task WriteMessage(string message);
    }
    #endregion
}
