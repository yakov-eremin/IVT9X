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

        [TestMethod]
        public void BoardGetSymbolTest()
        {
            Board b = new Board();
            char result = b.GetSymbol(0);
            Assert.AreEqual('-', result);
        }

        [TestMethod]
        public void BoardPutSymbolTest()
        {
            Board b = new Board();
            b.Put(5, 'x');
            char result = b.GetSymbol(5);
            Assert.AreEqual('x', result);
        }

        [TestMethod]
        public void BoardPutSymbolTest2()
        {
            Board b = new Board();
            b.Put(5, 'o');
            char result = b.GetSymbol(5);
            Assert.AreEqual('o', result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BoardPutSymbolTest3()
        {
            Board b = new Board();
            b.Put(5, 'k');
        }
    }
}
