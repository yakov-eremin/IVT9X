using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab4
{
    public class Library
    {
        private List<string> _answer;
        private List<string> _question;

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
    }
}
