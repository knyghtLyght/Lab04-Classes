using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04
{
    public class GameBoard
    {
        //Why static?
        private static string[,] gameBoard = new string[3, 3] { { "|0|", "|1|", "|2|" }, { "|3|", "|4|", "|5|" }, { "|6|", "|7|", "|8|" } };
        private int[,] locTrans = new int[9, 2] { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 2, 0 }, { 2, 1 }, { 2, 2 } };

        public string[,] Board { get; set; } = gameBoard;

        public string[,] UpdateBoard(int location, string symbol)
        {
            string[,] newBoard = gameBoard;
            newBoard[locTrans[location, 0], locTrans[location, 1]] = $"|{symbol}|";
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

        public bool CheckWinner(string[,] gameBoard)
        {
            //Checks from 00
            if (gameBoard[0,0] == gameBoard[0, 1] && gameBoard[0, 0] == gameBoard[0, 2]) //Top horizontal
            {
                return true;
            }
            else if (gameBoard[0, 0] == gameBoard[1, 0] && gameBoard[0, 0] == gameBoard[2, 0]) //Left vertical
            {
                return true;
            }
            else if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[0, 0] == gameBoard[2, 2]) //Backslash diagonal
            {
                return true;
            }
            //Checks from 01
            else if (gameBoard[0, 1] == gameBoard[1, 1] && gameBoard[0, 1] == gameBoard[2, 1]) //Middle vertical
            {
                return true;
            }
            //Checks from 02
            else if (gameBoard[0, 2] == gameBoard[1, 2] && gameBoard[0, 2] == gameBoard[2, 2]) //Right vertical
            {
                return true;
            }
            else if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[0, 2] == gameBoard[2, 0]) //Forwardslash diagonal
            {
                return true;
            }
            //Checks from 10
            else if (gameBoard[1, 0] == gameBoard[1, 1] && gameBoard[1, 0] == gameBoard[1, 2]) //Middle horizontal
            {
                return true;
            }
            //Checks from 20
            else if (gameBoard[2, 0] == gameBoard[2, 1] && gameBoard[2, 0] == gameBoard[2, 2]) //Bottom horizontal
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
