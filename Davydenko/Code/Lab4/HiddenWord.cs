using System;
using System.Collections.Generic;


namespace Lab4
{
    public class HiddenWord
    {
        private char[] _word;
        public char[] Word { get => _word; set => _word = value; }

        public HiddenWord(string word)
        {
            _word = word.ToCharArray();
        }

        public bool TryGuessLetter(char letter, List<int> index)
        {
            if(Array.IndexOf(_word, letter) != -1)
            {
                for(int i = 0; i < _word.Length; i++)
                {
                    if(_word[i] == letter)
                        index.Add(i);
                }                
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
