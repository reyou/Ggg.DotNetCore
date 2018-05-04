

using GggNetStandard.Basics;
using NUnit.Framework;

namespace GggNUnitTestProject
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit
    /// </summary>
    [TestFixture]
    public class PrimeServiceIsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeServiceIsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);
            Assert.IsFalse(result, "1 should not be prime");
        }

        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
    }
}
