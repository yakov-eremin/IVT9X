using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    public class SityGame
    {
        /*!
         
            /brief Метод проверяет есть ли город в списке городов
         
            \param [in] v Название города
        
            \param [out] bool Есть или Нет

        */

        public bool isSity(string v)
        {
            //todo Позже доделать весь функционал 
            return true;
        }

        /*!

            /brief Метод проверяет соблюдены ли правила игры

            \param [in] v1 Название города 1
            \param [in] v2 Название города 2

            \param [out] bool Соблюдены или нет

        */

        public bool Rules(string v1, string v2)
        {
            //todo Необоходимо добавить функционал, для городов
            //     которые кончаются на ь


            v2 = v2.ToLower();

            if (v1[v1.Length - 1].Equals(v2[0]))
            {
                return true;
            }

            return false;
        }

        /*!
         
            /brief Метод получает последнию букву города
         
            \param [in] v Название города
        
            \param [out] string Последняя буква города

        */

        public string GetLast(string v)
        {
            return v[v.Length - 1].ToString();
        }

        private string[] sityes;

        public string[] Sityes { get { return sityes; } }

        /*!

            /brief Метод считывает из файла название город в массив

        */

        public void ReadInMas()
        {
            string path = "goroda.txt";

            string Text;

            using (StreamReader reader = new StreamReader(path))
            {
                Text = reader.ReadToEnd();
            }

            sityes = Text.Split('\n');
        }
    }
}
