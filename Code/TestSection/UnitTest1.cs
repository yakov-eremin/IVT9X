using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab2_3;

namespace TestSection
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLength()
        {
            Section s = new Section();
            s.Init(0, 3, 4, 0);
            double first = s.Length();
            Assert.AreEqual(5, first);
        }

        [TestMethod]
        public void TestLenghtN()
        {
            Section s = new Section();
            s.Init(0, -3, -4, 0);
            double first = s.Length();
            Assert.AreEqual(5, first);
        }

        [TestMethod]
        public void TestLenghtNP()
        {
            Section s = new Section();
            s.Init(-3, 0, 0, 4);
            double first = s.Length();
            Assert.AreEqual(5, first);
        }
        
        [TestMethod]
        public void TestAdd()
        {
            Section s1 = new Section();
            Section s2 = new Section();
            Section sSum = new Section();
            Section s;
            s1.Init(2, 5, 3, 1);
            s2.Init(7, 4, 6, 3);
            sSum.Init(2, 5, 6, 3);
            s = s1.Add(s1, s2);
            Assert.AreEqual(s.Length(), sSum.Length());
        }

        [TestMethod]
        public void TestAddDoubleN()
        {
            Section s1 = new Section();
            Section s2 = new Section();
            Section sSum = new Section();
            Section s;
            s1.Init(3.2, -2.1, 4.8, 2.11);
            s2.Init(-3, -6.29, -1.53, 12.4);
            sSum.Init(3.2, -2.1, -1.53, 12.4);
            s = s1.Add(s1, s2);
            Assert.AreEqual(s.Length(), sSum.Length());
        }
        
        [TestMethod]
        public void TestAreaPP()
        {
            Section s = new Section();
            s.Init(2, 4.7, 23, 1.11);
            double result = s.Area();
            Assert.AreEqual(1, result);
        }
        
        [TestMethod]
        public void TestAreaNN()
        {
            Section s = new Section();
            s.Init(-2, -4.7, -23, -1.11);
            double result = s.Area();
            Assert.AreEqual(-1, result);
        }
        
        [TestMethod]
        public void TestAreaPN()
        {
            Section s = new Section();
            s.Init(2, -4.7, 23, -1.11);
            double result = s.Area();
            Assert.AreEqual(0.5, result);
        }

        
        [TestMethod]
        public void TestAreaNP()
        {
            Section s = new Section();
            s.Init(-2, 4.7, -23, 1.11);
            double result = s.Area();
            Assert.AreEqual(-0.5, result);
        }

        [TestMethod]
        public void TestAreaZ()
        {
            Section s = new Section();
            s.Init(-2, 4.7, 23, -1.11);
            double result = s.Area();
            Assert.AreEqual(0, result);
        }


    }
}
