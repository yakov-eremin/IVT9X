using lab4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void BoardInitTest()
        {
            Board b = new Board();
        }
    }
}
