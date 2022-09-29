using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab_4_QA;

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
    }
}
