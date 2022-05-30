using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA_Lab4_Form;
namespace QA_Lab4_Tests
{
    [TestClass]
    public class NumberClass
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

        public void OldRussianToSiTest()
        {
            Number number = new Number();
            double expected = 0.7112;
            number.SetCurrent(1);
            double actual = number.FromOldRussianToSI();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AmericanToSiTest()
        {
            Number number = new Number();
            double expected = 0.7112;
            number.SetCurrent(1);
            double actual = number.FromAmericanToSI();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void AmericanToOldRussianTest()
        {
            Number number = new Number();
            double expected = 1.2857;
            number.SetCurrent(1);
            double actual = number.FromAmericanToOldRussian();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void OldRussianToAmericanTest()
        {
            Number number = new Number();
            double expected = 0.7778;
            number.SetCurrent(1);
            double actual = number.FromOldRussianToAmerican();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SIToOldRussianTest()
        {
            Number number = new Number();
            double expected = 1.4061;
            number.SetCurrent(1);
            double actual = number.FromSIToOldRussian();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        public void SIToAmericanTest()
        {
            Number number = new Number();
            double expected = 1.0936;
            number.SetCurrent(1);
            double actual = number.FromSIToAmerican();
            Assert.AreEqual(expected, actual);
        }
    }
}