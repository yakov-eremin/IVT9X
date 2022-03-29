using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
