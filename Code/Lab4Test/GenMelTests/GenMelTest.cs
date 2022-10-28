using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenMelTest
{
    [TestClass]
    public class GenMelTest
    {
        [TestMethod]
        public void vvod1()
        {
            string a1 = "C";
            string a2 = "C";
            string a3 = "F";
            string a4 = "E";
            string ex = "C C F E";

            Accord a = new Accord();
            string act = a.vvod(a1, a2, a3, a4);

            Assert.AreEqual(ex, act);
        }
       

    }
}
