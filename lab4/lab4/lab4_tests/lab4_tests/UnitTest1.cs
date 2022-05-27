using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab4_form;
namespace lab4_tests
{
    [TestClass]
    public class NumberTest
    {
        Number number = new Number();
        [TestMethod]

        public void NumberCreation()
        {
            Number number = new Number();
            Assert.IsNotNull(number);
        }

        [TestMethod]

        public void CurrentValue()
        {
            double _current = 1;
            Assert.AreEqual(number.GetCurrent(), _current);
        }

    }
}