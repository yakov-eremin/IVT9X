using System;

namespace lab4
{
    public class Board
    {
        private char[,] board = new char[3, 3];

        public Board()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = '-';
        }

        public char GetSymbol(int number)
        {
            return board[number / 3, number % 3];
        }

        public void Put(int number, char symbol)
        {
            if ((symbol != 'x' && symbol != 'o') || number < 0 || number > 8)
                throw new ArgumentException("Некорректные данные");
            board[number / 3, number % 3] = symbol;
        }
    }
}
