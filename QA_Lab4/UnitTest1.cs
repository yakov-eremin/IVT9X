using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab4_QA;
using System.Threading;

namespace UnitTests
{
    [TestClass]
    public class TimerTests
    {
        [TestMethod]
        public void TimerIsNotNullTest()
        {
            Timer timer = new Timer();
            Assert.IsNotNull(timer);
        }
    }
}