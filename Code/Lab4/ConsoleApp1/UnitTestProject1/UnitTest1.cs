using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TagsGame_init()
        {
            TagsGame g = new TagsGame();
            Assert.IsNotNull(g);
        }
    }
}
