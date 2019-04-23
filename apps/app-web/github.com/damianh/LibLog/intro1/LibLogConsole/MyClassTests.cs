using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace LibLogConsole
{
    [TestClass]
    public class MyClassTests
    {
        [TestMethod]
        public void IsNotNull()
        {
            MyClass myClass = new MyClass();
            Assert.IsNotNull(myClass);
        }
    }

}
