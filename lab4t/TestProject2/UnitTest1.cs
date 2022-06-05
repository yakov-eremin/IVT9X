using lab4;
using NUnit.Framework;

namespace TestProject2
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Create_Class_Calculate()
        {
            Calculate calc = new Calculate(); 
            Assert.IsNotNull(calc);
        }

        [Test]
        public void Test_Method_dollar_in_rub()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(6300, calc.dollarinrub(63, 100));
        }
    }
}