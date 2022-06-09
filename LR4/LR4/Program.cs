using System;
using System.Collections.Generic;
using System.Linq;

namespace WhatWordGame
{
    
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

namespace LR4
{
    public class word_pole
    {
        public List<string> words = new List<string>() { "буква", "цифра", "число", "знак", "представление" };

        public int get_score()
        {
            return -10;
        }

        public string set_word()
        {
            return "word";
        }

        public string set_secret(string expected)
        {
            return "tt";
        }

        public void DW(string word)
        {
            words.Remove(word);
        }

        public void fl()
        {
            throw new NotImplementedException();
        }
    }
}