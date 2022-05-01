using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_4;

namespace TestLab4
{
    [TestClass]
    public class TestSityGame
    {
        [TestMethod]
        public void TestCreateObjectClass()
        {
            SityGame sg = new SityGame();

            Assert.IsNotNull(sg);
        }

        [TestMethod]
        public void CheckSityTest()
        {
            SityGame sg = new SityGame();

            Assert.IsTrue(sg.isSity("Волгоград"));

        }

        [TestMethod]
        public void CheckRightGameRuleTest()
        {
            SityGame sg = new SityGame();

            Assert.IsTrue(sg.Rules("Борисов", "Волгоград"));
        }
    }
}