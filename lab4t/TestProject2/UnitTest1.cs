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

        [Test]
        public void Test_Method_rub_in_dollar()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(100, calc.rubindollar(6300, 63));
        }

        [Test]
        public void Test_Method_rub_in_euro()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(100, calc.rubineuro(7500, 75));
        }

        [Test]
        public void Test_Method_euro_in_rub()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(7500, calc.euroinrub(75, 100));
        }

        [Test]
        public void Test_Method_euro_in_dollar()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(106, calc.euroindollar(1.06, 100));
        }

        [Test]
        public void Test_Method_dollar_in_euro()
        {
            Calculate calc = new Calculate();
            Assert.AreEqual(100, calc.dollarineuro(1.06, 106));
        }
    }
}