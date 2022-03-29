using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class Library
    {
        private string _answer = "Answer";
        private string _question = "Question";

        public string Answer { get => _answer; set => _answer = value; }
        public string Question { get => _question; set => _question = value; }
    }
}
