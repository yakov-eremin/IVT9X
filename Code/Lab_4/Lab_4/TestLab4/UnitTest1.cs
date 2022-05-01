using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestLab4
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreateObjectClass()
        {
            SityGame sg = new SityGame();

            Assert.IsNotNull(sg);
        }
    }
}