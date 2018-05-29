using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace SerilogConsole
{
    [TestClass]
    public class SerilogExampleTests
    {
        [TestMethod]
        public void Main2()
        {
            Debugger.Break();
            SerilogExample.Main2();
        }
    }
}
