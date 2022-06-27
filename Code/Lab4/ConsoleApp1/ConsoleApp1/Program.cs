using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TagsGame game = new TagsGame();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Управление стрелками, клавиши: q - выйти, n - новая игра");
                game.DisplayBoard();

                if (game.CheckBoard())
                {
                    Console.WriteLine("Игра окончена, кол-во ходов: " + game.GetCount());
                    Console.ReadKey();
                    break;
                }

                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                    game.MoveTop();
                else if (key.Key == ConsoleKey.DownArrow)
                    game.MoveBottom();
                else if (key.Key == ConsoleKey.LeftArrow)
                    game.MoveLeft();
                else if (key.Key == ConsoleKey.RightArrow)
                    game.MoveRight();
                else if (key.Key == ConsoleKey.N)
                    game.FillBoard();
                else if (key.Key == ConsoleKey.Q)
                    break;
            }
            Console.ReadKey();
        }
    }
}
