using System;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            int pos;
            string str;
            bool sw = false;

            Board board = new Board();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Игра \"Крестики-нолики\"");
                Console.WriteLine("Чтобы поставить символ, используйте цифры от 1 до 9");
                Console.WriteLine("Чтобы начать новую игру и очистить поле, введите reset");
                Console.WriteLine("Чтобы выйти из программы, введите exit\n\n");

                board.ClearBoard();
                board.PrintBoard();
                while (true)
                {
                    Console.WriteLine("Куда поставить " + ((sw) ? "нолик" : "крестик") + "? (1 - 9)");
                    str = Console.ReadLine();
                    if (str == "reset")
                    {
                        board.ClearBoard();
                        board.PrintBoard();
                        continue;
                    }
                    if (str == "exit") break;
                    pos = int.Parse(str);
                    try
                    {
                        board.Put(pos - 1, (sw) ? 'o' : 'x');
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        continue;
                    }
                    board.PrintBoard();
                    if (board.CheckWin())
                    {
                        Console.WriteLine(((sw) ? "нолик" : "крестик") + " победил");
                        break;
                    }
                    sw = !sw;
                }
                Console.WriteLine("Хотите начать новую игру? (yes/no)");
                str = Console.ReadLine();
                if (str == "no") break;
                if (str == "yes") continue;
            }
            Console.ReadKey();
        }
    }
}
