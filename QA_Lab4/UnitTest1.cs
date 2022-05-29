using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA_Lab4_Form; 


namespace QA_Lab4_Tests
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void NumberCreation()
        {
            Number number = new Number();
            Assert.IsNotNull(number);
        }

        [TestMethod]
        public void CurrentTest()
        {
            Number number = new Number();
            double expected = 1;
            number.SetCurrent(1);
            double actual = number.GetCurrent();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void From0To2Test()
        {
            Number number = new Number();
            double expected = 0.7112;
            number.SetCurrent(1);
            double actual = number.From0To2();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void From1To2Test()
        {
            Number number = new Number();
            double expected = 0.9114;
            number.SetCurrent(1);
            double actual = number.From1To2();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void From1To0Test()
        {
            Number number = new Number();
            double expected = 1.2857;
            number.SetCurrent(1);
            double actual = number.From1To0();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void From0To1Test()
        {
            Number number = new Number();
            double expected = 0.7778;
            number.SetCurrent(1);
            double actual = number.From0To1();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void From2To0Test()
        {
            Number number = new Number();
            double expected = 1.4061;
            number.SetCurrent(1);
            double actual = number.From2To0();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void From2To1Test()
        {
            Number number = new Number();
            double expected = 1.0936;
            number.SetCurrent(1);
            double actual = number.From2To1();
            Assert.AreEqual(expected, actual);
        }
    }
}