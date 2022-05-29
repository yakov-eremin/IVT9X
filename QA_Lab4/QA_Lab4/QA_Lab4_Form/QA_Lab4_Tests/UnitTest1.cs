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

        public void CurrentValue()
        { 
        }
    }
}