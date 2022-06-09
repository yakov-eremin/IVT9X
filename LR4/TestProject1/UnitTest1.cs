using LR4;
using NUnit.Framework;
using WhatWordGame;
namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateClass()
        {
             word_pole word1 = new word_pole();
            Assert.NotNull(word1);
        }

        [Test]
        public void TestGet_score()
        {

            int expected = -10;


            word_pole word1 = new word_pole();
            int actual = word1.get_score();

            Assert.AreEqual(expected, actual);


        }


        [Test]
        public void TestSetWord()
        {
            string expected = "";
            string actual = "";

            word_pole word1 = new word_pole();
            actual = word1.set_word();

            Assert.AreNotEqual(expected, actual);

        }

        [Test]
        public void TestSet_Secret()
        {

            string expected = "";
            string actual = "";
            word_pole word1 = new word_pole();
            actual = word1.set_word();
            expected = word1.set_secret(actual);
            Assert.AreEqual(expected.Length, actual.Length);

        }

        [Test]
        public void TestDW()
        {

            word_pole word1 = new word_pole();
            string word = "буква";
            word1.DW(word);

            Assert.IsFalse(word1.words.Contains("буква"));

        }

    }
}