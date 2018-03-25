using System;
using System.Text.RegularExpressions;

namespace Lab04
{
    public class Program
    {
        static void Main(string[] args)
        {
            MenuLoop();
        }

        public static void MenuLoop()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Would you like to play a game?\ny or n?");
                string startGame = Console.ReadLine().ToLower();
                if (startGame == "y")
                {
                    Console.WriteLine("Welcome to Tic-Tac-Toe\nLets get our players!");
                    Player playerOne = (PlayerSetup("One"));
                    Player playerTwo = (PlayerSetup("Two"));

                    Console.WriteLine($"Player one is {playerOne.Name} Using {playerOne.Symbol}");
                    Console.WriteLine($"Player two is {playerTwo.Name} Using {playerTwo.Symbol}");

                    Console.ReadLine();

                    GameLoop(playerOne, playerTwo);
                }
                else if (startGame == "n")
                {
                    loop = false;
                }
                else
                {
                    Console.WriteLine("I'm sorry that was not one of your choices.");
                }
            }
        }

        public static Player PlayerSetup(string playerNum)
        {
            try
            {
                Console.WriteLine($"Player {playerNum} please state your name.");
                string playerName = Console.ReadLine();
                string playerSymbol = "X";
                while (true)
                {
                    Console.WriteLine($"Player {playerNum} please chose a non-numeric symbol to represetn your markers.");
                    playerSymbol = Console.ReadLine();
                    if (playerSymbol.Length > 1 && !(Regex.IsMatch(playerSymbol, @"[0-9]")))
                    {
                        Console.WriteLine("I'm sorry that is not a valid response");
                        Console.WriteLine(); //Console formating
                    }
                    else
                    {
                        break;
                    }
                }
                return new Player(playerName, playerSymbol);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void GameLoop(Player playerOne, Player playerTwo)
        {
            GameBoard gameBoard = new GameBoard();
            Console.WriteLine("Lets play!");
            bool winCheck = true;
            string winner = "";
            while (winCheck)
            {
                MakeMove(playerOne, gameBoard);
                if (gameBoard.CheckWinner(gameBoard.Board))
                {
                    winCheck = false;
                    winner = playerOne.Name;
                }
                MakeMove(playerTwo, gameBoard);
                if (gameBoard.CheckWinner(gameBoard.Board))
                {
                    winCheck = false;
                    winner = playerTwo.Name;
                }
            }
            Console.WriteLine($"The winner is {winner}\n\n1) Play again\n2) Return to menu");

        }

        public static void MakeMove(Player player, GameBoard gameBoard)
        {
            try
            {
                Console.WriteLine(); //Console formating
                Console.WriteLine(gameBoard.StringBoard(gameBoard.Board));
                Console.WriteLine(); //Console formating
                Console.WriteLine($"{player.Name} please make your move by choosing a space. Enter 9 to go back to the menu.");
                int target = int.Parse(Console.ReadLine());
                if (target == 9)
                {
                    MenuLoop();
                }
                else
                {
                    gameBoard.UpdateBoard(target, player.Symbol);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
