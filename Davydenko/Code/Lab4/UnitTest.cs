using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab4;

namespace TestProject
{
    [TestClass]
    public class LibraryTests
    {
        Library _library;

        [TestInitialize]
        public void LibraryInitializeTest()
        {
            string path = "TestXmlFile.xml";
            _library = new Library(path);
            Assert.IsNotNull(_library);
        }

        [TestMethod]
        public void ReturnAnswerTest()
        {
            List<string> _answer = new List<string> { "Жупа", "Чихание" };
            for (int i = 0; i < _answer.Count; i++)
            {
                Assert.AreEqual(_library.Answer[i], _answer[i]);
            }
                         
        }
        [TestMethod]
        public void ReturnQuestionTest()
        {
            List<string> _questions = new List<string> { "Как у западных", "Человеческие способности" };
            for (int i = 0; i < _questions.Count; i++)
            {
                Assert.AreEqual(_library.Question[i], _questions[i]);
            }            
        }

        [TestMethod]
        public void GetRandomPuzzleTestAccordance()
        {
            string _question;
            string _answer;
            Library.GetRandomPuzzle(out _question, out _answer);
            Assert.AreEqual(_library.Question.IndexOf(_question), _library.Answer.IndexOf(_answer));
        }
    }

    [TestClass]
    public class PlayerTests
    {
        Player _player;
        [TestInitialize]
        public void PlayerInitializeTest()
        {
            _player = new Player();
            Assert.IsNotNull(_player);
        }
        [TestMethod]
        public void PlayerSetNameTest()
        {
            _player.Name = "Player1";
            Assert.AreEqual("Player1", _player.Name);
        }
        [TestMethod]
        public void PlayerSetPointsTest()
        {
            _player.Points = 10;
            Assert.AreEqual(10, _player.Points);
        }

        [TestMethod]
        public void IncreasePointsPositiveTest()
        {
            _player.IncreasePoints(800);
            Assert.AreEqual(800, _player.Points);
        }
        [TestMethod]
        public void IncreasePointsNegativeTest()
        {
            _player.IncreasePoints(-800);
            Assert.AreEqual(0, _player.Points);
        }
        [TestMethod]
        public void ResetPointsTest()
        {
            _player.ResetPoints();
            Assert.AreEqual(0, _player.Points);
        }
    }
    [TestClass]
    public class HiddenWordTests
    {
        HiddenWord _hiddenWord;
        [TestInitialize]
        public void HiddenWordInitializeTest()
        {
            _hiddenWord = new HiddenWord();
            Assert.IsNotNull(_hiddenWord);
        }
        [TestMethod]
        public void HiddenWordSetFromChar()
        {
            char[] _word = new char[] { 'H', 'e', 'l', 'l', 'o' };
            _hiddenWord.Word = _word;
            Assert.AreEqual(_word, _hiddenWord.Word);
        }
    }
}