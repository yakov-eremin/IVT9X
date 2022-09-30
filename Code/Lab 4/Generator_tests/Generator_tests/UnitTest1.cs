using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Generator_tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void getch_test1()
        {
            string c1 = "Am";
            string c2 = "G";
            string c3 = "F";
            string c4 = "Dm";
            string nab = "";
            string expected = "Am G F Dm";

            Accords s = new Accords();
            string actual = s.getch(c1, c2, c3, c4, nab);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void getch_test2()
        {
            string c1 = "B";
            string c2 = "C";
            string c3 = "G#";
            string c4 = "D#";
            string expected = "";

            Accords s = new Accords();
            Melody ff = new Melody();
            string actual = ff.getm(c1, c2, c3, c4);

            Assert.AreEqual(expected, actual);
        }
    }
}