using System;

namespace Lab04
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameBoard gameBoard = new GameBoard();
            Console.WriteLine(gameBoard.StringBoard(gameBoard.Board));
            Console.ReadLine();
        }
    }
}
