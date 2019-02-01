using System;

namespace GggNetStandard.Basics
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test
    /// Unit testing C# in .NET Core using dotnet test and xUnit
    /// </summary>
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }

            for (var divisor = 2; divisor <= Math.Sqrt(candidate); divisor++)
            {
                if (candidate % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
