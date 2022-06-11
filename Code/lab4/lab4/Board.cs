using System;

namespace lab4
{
    public class Board
    {
        private char[,] board = new char[3, 3];

        public Board()
        {
            ClearBoard();
        }

        public char GetSymbol(int number)
        {
            return board[number / 3, number % 3];
        }

        public void Put(int number, char symbol)
        {
            if ((symbol != 'x' && symbol != 'o') || number < 0 || number > 8)
                throw new ArgumentException("Некорректные данные");
            if (board[number / 3, number % 3] != '-')
                throw new ArgumentException("Этот символ уже занят");
            board[number / 3, number % 3] = symbol;
        }

        public void ClearBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = '-';
        }

        public bool CheckWin()
        {
            int[,] combinations = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 0, 4, 8 }, { 2, 4, 6 } };
            for (int i = 0; i < 8; i++)
            {
                if ((GetSymbol(combinations[i, 0]) == 'x' || GetSymbol(combinations[i, 0]) == 'o') && 
                    GetSymbol(combinations[i, 0]) == GetSymbol(combinations[i, 1]) &&
                    GetSymbol(combinations[i, 0]) == GetSymbol(combinations[i, 2]))
                    return true;
            }
            return false;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
