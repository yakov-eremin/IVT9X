using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_4_QA;
using System.Drawing;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TileCreation()
        {
            Tile tile = new Tile();
            Assert.IsNotNull(tile);
        }

        [TestMethod]
        public void SumScore()
        {
            Tile tile = new Tile();
            int sum = 20;
            Assert.AreEqual(tile.SumScore(15, 5), sum);
            
        }
            
    }
}
