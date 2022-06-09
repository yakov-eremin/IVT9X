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
        public Random rand = new Random();
        public int score;

        public int get_score()
        {
            return score;
        }

        public string set_word()
        {
            return "word";
        }

        public string set_secret(string word)
        {
            string secret = new String('*', word.Length);
            return secret;
        }

        public void DW(string word)
        {
            words.Remove(word);
        }

        public void fl()
        {
            score -= 10;
        }
    }
}