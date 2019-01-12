using Newtonsoft.Json;

namespace GggNetStandard.Basics
{
    // https://docs.microsoft.com/en-us/dotnet/core/tutorials/using-on-windows-full-solution
    public class Thing
    {
        public int Get(int number) => JsonConvert.DeserializeObject<int>($"{number}");

    }
}
