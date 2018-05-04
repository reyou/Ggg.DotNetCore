using GggNetStandard.Basics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GggUnitTestProject
{
    // The test class attribute
    [TestClass]
    public class PrimeServiceIsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeServiceIsPrimeShould()
        {
            _primeService = new PrimeService();
        }
        // The test method attribute
        [TestMethod]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
        // Attribute for data driven test where data can be specified inline
        [DataTestMethod]
        // Attribute to define inline data for a test method
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        public void ReturnFalseGivenValuesLessThan2(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.IsFalse(result, $"{value} should not be prime");
        }
    }
}
