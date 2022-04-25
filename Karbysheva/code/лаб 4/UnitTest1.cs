using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp8;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CitiesCreateTest()
        {
            Cities _cities = new Cities();
            Assert.IsNotNull(_cities);
        }
    }
}
