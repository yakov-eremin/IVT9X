using NUnit.Framework;
using lab4;

namespace TestsLab4
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateClass ()
        {
            Calculate calc = new Calculate();
            Assert.NotNull(calc);
        }
    }
}