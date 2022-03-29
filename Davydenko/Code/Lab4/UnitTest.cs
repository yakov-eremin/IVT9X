using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Lab4;

namespace TestProject
{
    [TestClass]
    public class LibraryTest
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
            Assert.AreEqual(library.Answer, _answer);             
        }
        [TestMethod]
        public void ReturnQuestionTest()
        {
            List<string> _questions = new List<string> { "Жупа", "Чихание" };
            Assert.AreEqual(library.Question, _questions);
        }
    }
}