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
    }
}