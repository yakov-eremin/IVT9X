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

            sg.ReadInMas();

            Assert.IsTrue(sg.isSity("Волгоград"));

        }

        [TestMethod]
        public void CheckRightGameRuleTest()
        {
            SityGame sg = new SityGame();

            Assert.IsTrue(sg.Rules("Борисов", "Волгоград"));
        }

        [TestMethod]
        public void LastBykvTest()
        {
            SityGame sg = new SityGame();

            Assert.AreEqual("в", sg.GetLast("Киров"));
        }

        [TestMethod]
        public void ReadInMasTest()
        {
            SityGame sg = new SityGame();

            sg.ReadInMas();

            Assert.AreEqual(1117, sg.Sityes.Length);
        }
    }
}