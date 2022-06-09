using System;
using System.Collections.Generic;
using System.Linq;

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
            string word = words[rand.Next(words.Count)];
            return word;
        }

        public string set_secret(string word)
        {
            string secret = new String('*', word.Length);
            return secret;
        }

        public void fail()
        {

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
            Console.ReadLine();
        }
        public void DW(string word)
        {
            words.Remove(word);
            if (words.Count == 0)
            {
                Console.WriteLine("Все слова из списка угаданы.");
                fail();
            }
        }

        public void win(string word)
        {
            score += 100;
            Console.WriteLine("Верно! Это слово: {0}. Счёт игры: {1}", word, score);
            Console.WriteLine("Нажмите любую клавишу для продолжения игры...");
            Console.ReadKey();
        }
        public void fl()
        {
            score -= 10;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool k = true;
            while (k == true)
            {
                word_pole word1 = new word_pole();
                string word = word1.set_word();
                string secret = word1.set_secret(word);
                var errcount = 7;
                while (word != secret)
                {
                    var ch = string.Empty;
                    do
                    {
                        Console.WriteLine("\nСлово: {0} Счёт игры: {1}, осталось попыток: {2}",
                                          secret, word1.get_score(), errcount);
                        Console.Write("Введите букву или всё слово: ");
                        ch = Console.ReadLine();
                        if (ch.Length > 1)
                        {
                            if (ch == word)
                            {
                                word1.win(word);
                                word1.DW(word);
                                word = word1.set_word();
                                secret = word1.set_secret(word);

                            }

                            else
                            {
                                Console.WriteLine("Не угадано слово: {0} при досрочном ответе", word);

                            }
                        }
                    } while (ch.Length != 1);

                    if (word.Contains(ch))
                    {
                        var list = secret.ToCharArray();
                        for (var i = 0; i < word.Length; i++)
                            if (word[i] == ch[0])
                                list[i] = ch[0];
                        secret = new string(list.ToArray());
                        if (secret == word) word1.win(word);
                    }
                    else
                    {
                        word1.fl();
                        errcount--;
                        if (errcount < 0)
                        {
                            Console.WriteLine("Превышено количество попыток угадать слово: {0}", word);
                            word1.fail();
                            k = false;
                            break;

                        }
                    }
                }

            }

        }
    }
}