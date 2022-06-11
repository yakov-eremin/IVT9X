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

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BoardPutSymbolTest4()
        {
            Board b = new Board();
            b.Put(-1, 'x');
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BoardPutSymbolTest5()
        {
            Board b = new Board();
            b.Put(5, 'x');
            b.Put(5, 'x');
        }

        [TestMethod]
        public void BoardClearTest()
        {
            Board b = new Board();
            b.Put(0, 'x');
            b.ClearBoard();

            char result = b.GetSymbol(0);
            Assert.AreEqual('-', result);
        }

        [TestMethod]
        public void BoardCheckWinTest()
        {
            Board b = new Board();
            b.Put(0, 'x');
            b.Put(1, 'x');
            b.Put(2, 'x');
            Assert.IsTrue(b.CheckWin());
        }

        [TestMethod]
        public void BoardCheckWinTest2()
        {
            Board b = new Board();
            b.Put(0, 'o');
            b.Put(1, 'o');
            b.Put(2, 'x');
            Assert.IsFalse(b.CheckWin());
        }
    }
}
