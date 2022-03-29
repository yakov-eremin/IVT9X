using System;
using System.Collections.Generic;
using System.Xml;

namespace Lab4
{
    public class Library
    {
        private static List<string> _answer;
        private static List<string> _question;

        public List<string> Answer { get => _answer; set => _answer = value; }
        public List<string> Question { get => _question; set => _question = value; }

        public Library(string path)
        {
            _answer = new List<string>();
            _question = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            XmlElement xRoot = xmlDoc.DocumentElement;
            if (xRoot != null)
            {
                foreach (XmlElement element in xRoot)
                {
                    if (element.Name == "Question")
                    {
                        _question.Add(element.InnerText);
                    }
                    if (element.Name == "Answer")
                    {
                        _answer.Add(element.InnerText);
                    }
                }
            }
        }

        public static void GetRandomPuzzle(out string question, out string answer )
        {
            var random = new Random();
            int index = random.Next(0, _question.Count);
            question = _question[index];
            answer = _answer[index];
        }
    }
}
