using ConsoleApp3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Van_init()
        {
            Van v = new Van();
            v.Init(10, 100);
            Assert.IsNotNull(v);
        }

        [TestMethod]
        public void Van_income1()
        {
            Van v = new Van();
            v.Init(10, 100);
            double expected = 1000;

            double result = v.Income();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Van_income2()
        {
            Van v = new Van();
            v.Init(50, 3400);
            double expected = 170000;

            double result = v.Income();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Train_init()
        {
            Train tr = new Train();
            tr.Init("test", 10, 100, 20, 200, 30, 300, 0, 50, 100);
            Assert.IsNotNull(tr);
        }

        [TestMethod]
        public void Train_init2()
        {
            Van v1 = new Van();
            Van v2 = new Van();
            Van v3 = new Van();
            Train tr = new Train();
            v1.Init(10, 100);
            v2.Init(20, 200);
            v3.Init(30, 300);
            tr.Init("test", v1, v2, v3, 100, 50, 100);
            Assert.IsNotNull(tr);
        }

        [TestMethod]
        public void Train_income1()
        {
            Train tr = new Train();
            tr.Init("test", 10, 100, 20, 200, 30, 300, 0, 50, 100);
            double expected = 9000;

            double result = tr.Income();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Train_income2()
        {
            Van v1 = new Van();
            Van v2 = new Van();
            Van v3 = new Van();
            Train tr = new Train();
            v1.Init(10, 100);
            v2.Init(20, 200);
            v3.Init(30, 300);
            tr.Init("test", v1, v2, v3, 100, 50, 100);
            double expected = 2000;

            double result = tr.Income();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Train_null_argument()
        {
            Van v1 = new Van();
            Van v2 = new Van();
            Train tr = new Train();
            v1.Init(10, 100);
            v2.Init(20, 200);
            tr.Init("test", v1, v2, null, 100, 50, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Train_negative_percent()
        {
            Van v1 = new Van();
            Van v2 = new Van();
            Van v3 = new Van();
            Train tr = new Train();
            v1.Init(10, 100);
            v2.Init(20, 200);
            v3.Init(30, 300);
            tr.Init("test", v1, v2, v3, -100, 50, 100);
        }

        [TestMethod]
        public void Train_worst()
        {
            Van v1 = new Van();
            Van v2 = new Van();
            Van v3 = new Van();
            Train tr = new Train();
            v1.Init(10, 100);
            v2.Init(30, 300);
            v3.Init(20, 200);
            tr.Init("test", v1, v2, v3, 100, 100, 100);
            double expected = 1000;

            double result = tr.Worst().Income();

            Assert.AreEqual(expected, result);
        }
    }
}
