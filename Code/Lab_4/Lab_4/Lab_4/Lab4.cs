using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4
{
    internal class Lab4
    {
        static void Main(string[] args)
        {
            SityGame game = new SityGame();

            string sity1, sity2 = "";

            Console.WriteLine("Игра началась. Чтобы выйти наберите 0\n");
            Console.WriteLine("Начинает игрок 1. Введите любой город: ");

            sity1 = Console.ReadLine();

            bool ch = true;

            while (ch)
            {
                bool checkWord1 = true;

                while(checkWord1)
                {
                    if (game.isSity(sity1))
                    {
                        checkWord1 = false;

                        if (sity2 != "")
                        {
                            bool check1 = true;

                            while(check1)
                            {
                                if (game.Rules(sity2, sity1))
                                {
                                    Console.WriteLine("Игроку 2 нужно назвать город на букву: " + game.GetLast(sity1));

                                    sity2 = Console.ReadLine();

                                    check1 = false;
                                }
                                else
                                {
                                    Console.WriteLine("Вы не соблюдаете правило, введенный город не начинается на " + game.GetLast(sity1) + "\nВведите город заново:");
                                    sity1 = Console.ReadLine();
                                }
                            }

                           
                        } else
                        {
                            Console.WriteLine("Игроку 2 нужно назвать город на букву: " + game.GetLast(sity1));

                            sity2 = Console.ReadLine();
                        }

                        bool checkWord2 = true;

                        while (checkWord2)
                        {
                            if (game.isSity(sity2))
                            {
                                checkWord2 = false;

                                bool check2 = true;

                                while (check2)
                                {
                                    if (game.Rules(sity1, sity2))
                                    {
                                        check2 = false;
                                        Console.WriteLine("Следующий раунд.\nИгроку 1 нужно назвать город на букву " + game.GetLast(sity2));
                                        sity1 = Console.ReadLine();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Вы не соблюдаете правило, введенный город не начинается на " + game.GetLast(sity1) + "\nВведите город заново:");
                                        sity2 = Console.ReadLine();
                                    }
                                }

                            } else
                            {
                                if (sity2 == "0")
                                {
                                    checkWord2 = false;
                                    ch = false;
                                }
                                    
                                else
                                {
                                    Console.WriteLine("Вы ввели не правильный город. Введите город заново:");
                                    sity2 = Console.ReadLine();
                                }

                            }
                        }

                    } else
                    {
                        if (sity1 == "0")
                        {
                            checkWord1 = false;
                            ch = false;
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели не правильный город. Введите город заново:");
                            sity1 = Console.ReadLine();
                        }

                    }
                }

            }
        }
    }
}
