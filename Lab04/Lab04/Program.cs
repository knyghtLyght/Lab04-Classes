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
        /// <summary>
        /// Menu loop logic intended to provide error checking and repeatabilitys
        /// </summary>
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
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("I'm sorry that was not one of your choices.");
                }
            }
        }
        /// <summary>
        /// Player object instantiation logic with error checking and correction
        /// </summary>
        /// <param name="playerNum"></param>
        /// <returns></returns>
        public static Player PlayerSetup(string playerNum)
        {
            try
            {
                Console.WriteLine($"Player {playerNum} please state your name.");
                string playerName = Console.ReadLine();
                string playerSymbol = "X"; //Defult player symbol
                while (true)
                {
                    Console.WriteLine($"Player {playerNum} please chose a non-numeric, single character symbol to represetn your markers.");
                    playerSymbol = Console.ReadLine();
                    if (playerSymbol.Length > 1 && !(Regex.IsMatch(playerSymbol, @"[0-9]"))) //TODO Regex not yet working correctly
                    {
                        Console.WriteLine("I'm sorry that is not a valid response");
                        Console.WriteLine(); //Console formating
                    }
                    else
                    {
                        break; //End the loop
                    }
                }
                return new Player(playerName, playerSymbol);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Game loop logic with move, new game and exit options
        /// </summary>
        /// <param name="playerOne"></param>
        /// <param name="playerTwo"></param>
        public static void GameLoop(Player playerOne, Player playerTwo)
        {
            GameBoard gameBoard = new GameBoard();
            Console.WriteLine("Lets play!");
            bool winCheck = true;
            string winner = "";
            while (winCheck)
            {
                MakeMove(playerOne, gameBoard);
                if (gameBoard.CheckWinner(gameBoard.Board)) //Checks for a winner. If found break the loop
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
            try
            {
                while (true) //New game or exit loop
                {
                    Console.WriteLine(gameBoard.StringBoard(gameBoard.Board)); //Display current board state
                    Console.WriteLine($"The winner is {winner}\n\n1) Play again\n2) Return to menu");
                    int playerPath = int.Parse(Console.ReadLine()); //user choice variable
                    if (playerPath == 1)
                    {
                        GameLoop(playerOne, playerTwo); //Play a new game with the same players
                    }
                    if (playerPath == 2)
                    {
                        MenuLoop(); //Exit to menu
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Move structure and exit options
        /// </summary>
        /// <param name="player"></param>
        /// <param name="gameBoard"></param>
        public static void MakeMove(Player player, GameBoard gameBoard)
        {
            try
            {
                Console.WriteLine(); //Console formating
                Console.WriteLine(gameBoard.StringBoard(gameBoard.Board)); //Display current board state
                Console.WriteLine(); //Console formating
                Console.WriteLine($"{player.Name} please make your move by choosing a space. Enter 9 to go back to the menu.");
                int target = int.Parse(Console.ReadLine()); //player choice variable
                if (target == 9)
                {
                    MenuLoop(); //Exit to menu
                }
                else
                {
                    gameBoard.Board = gameBoard.UpdateBoard(target, player.Symbol); //Update the board state
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
