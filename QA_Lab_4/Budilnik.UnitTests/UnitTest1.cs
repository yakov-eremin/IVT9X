using budilnik;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;


namespace Budilnik.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_timer_method()
        {
            Timer timer = new Timer();
            Assert.IsNotNull(timer);
        }
        [TestMethod]
        public void Test_get_interval()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = Form1.Get_Interval(timer);
        }
    }
}



