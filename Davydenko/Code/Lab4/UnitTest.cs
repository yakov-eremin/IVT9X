using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab4;

namespace TestProject
{
    [TestClass]
    public class LibraryTests
    {
        Library library;

        [TestInitialize]
        public void LibraryInitializeTest()
        {
            string path = "TestXmlFile.xml";
            library = new Library(path);
            Assert.IsNotNull(library);
        }

        [TestMethod]
        public void ReturnAnswerTest()
        {
            List<string> _answer = new List<string> { "Жупа", "Чихание" };
            for (int i = 0; i < _answer.Count; i++)
            {
                Assert.AreEqual(library.Answer[i], _answer[i]);
            }
                         
        }
        [TestMethod]
        public void ReturnQuestionTest()
        {
            List<string> _questions = new List<string> { "Как у западных", "Человеческие способности" };
            for (int i = 0; i < _questions.Count; i++)
            {
                Assert.AreEqual(library.Question[i], _questions[i]);
            }            
        }

        [TestMethod]
        public void GetRandomPuzzleTestAccordance()
        {
            string _question;
            string _answer;
            Library.GetRandomPuzzle(out _question, out _answer);
            Assert.AreEqual(library.Question.IndexOf(_question), library.Answer.IndexOf(_answer));
        }
    }

    [TestClass]
    public class PlayerTests
    {

        [TestMethod]
        public void PlayerInitializeTest()
        {
            Player player = new Player();
            Assert.IsNotNull(player);
        }
    }
}