using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04
{
    class GameBoard
    {
        //Why static?
        private static string[,] gameBoard = new string[3, 3] { { "|@|", "|@|", "|@|" }, { "|@|", "|@|", "|@|" }, { "|@|", "|@|", "|@|" } };

        public string[,] Board { get; set; } = gameBoard;

        public string[,] UpdateBoard(int location)
        {
            string[,] newBoard = new string[3, 3];

            return newBoard;
        }

        public string StringBoard(string[,] gameBoard)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append($"{gameBoard[0, 0]} {gameBoard[0, 1]} {gameBoard[0, 2]}\n");
            sb.Append($"{gameBoard[1, 0]} {gameBoard[1, 1]} {gameBoard[1, 2]}\n");
            sb.Append($"{gameBoard[2, 0]} {gameBoard[2, 1]} {gameBoard[2, 2]}\n");

            return sb.ToString();
        }
    }
}
