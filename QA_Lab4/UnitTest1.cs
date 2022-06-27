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
            System.Timers.Timer timer = new System.Timers.Timer();
            Assert.IsNotNull(timer);
        }

        [TestMethod]

        public void TimerIntervalTest()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            Assert.AreEqual(1000, timer.Interval);
        }
    }
}