using ConsoleApp1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TagsGame_init()
        {
            TagsGame g = new TagsGame();
            Assert.IsNotNull(g);
        }

        [TestMethod]
        public void TagsGame_set()
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TagsGame_set2()
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
        }

        [TestMethod]
        public void TagsGame_get()
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
            CollectionAssert.AreEqual(array, g.GetBoard());
        }

        [TestMethod]
        public void TagsGame_fill()
        {
            TagsGame g = new TagsGame();
            g.FillBoard();
        }

        [TestMethod]
        public void TagsGame_check_true()
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
            Assert.IsTrue(g.CheckBoard());
        }

        [TestMethod]
        public void TagsGame_check_false()
        {
            int[,] array = new int[,] { { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 1, 2, 3, 4 }, { 13, 14, 15, 0 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
            Assert.IsFalse(g.CheckBoard());
        }

        [TestMethod]
        public void TagsGame_move_left()
        {
            int[,] array = new int[,] { { 1, 2, 0, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            int[,] expected = new int[,] { { 1, 2, 3, 0 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
            g.MoveLeft();
            CollectionAssert.AreEqual(expected, g.GetBoard());
        }

        [TestMethod]
        public void TagsGame_move_right()
        {
            int[,] array = new int[,] { { 1, 2, 0, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            int[,] expected = new int[,] { { 1, 0, 2, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
            g.MoveRight();
            CollectionAssert.AreEqual(expected, g.GetBoard());
        }

        [TestMethod]
        public void TagsGame_move_top()
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 0, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            int[,] expected = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 10, 7 }, { 8, 9, 0, 11 }, { 12, 13, 14, 15 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
            g.MoveTop();
            CollectionAssert.AreEqual(expected, g.GetBoard());
        }

        [TestMethod]
        public void TagsGame_move_bottom()
        {
            int[,] array = new int[,] { { 1, 2, 3, 4 }, { 5, 6, 0, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            int[,] expected = new int[,] { { 1, 2, 0, 4 }, { 5, 6, 3, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } };
            TagsGame g = new TagsGame();
            g.SetBoard(array);
            g.MoveBottom();
            CollectionAssert.AreEqual(expected, g.GetBoard());
        }

        [TestMethod]
        public void TagsGame_count()
        {
            TagsGame g = new TagsGame();
            g.SetBoard(new int[,] { { 1, 2, 0, 3 }, { 4, 5, 6, 7 }, { 8, 9, 10, 11 }, { 12, 13, 14, 15 } });
            g.MoveTop();
            g.MoveBottom();
            Assert.AreEqual(2, g.GetCount());
        }
    }
}
