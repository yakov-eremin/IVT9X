using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CheckStringTest()
        {
            CheckString check = new CheckString();
            Assert.IsNotNull(check);
        }
    }
}