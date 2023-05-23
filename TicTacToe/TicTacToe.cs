// Jay Bai
// Cs3Apps
// TINFO-200

////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-03-11       Jay             Initial file creation
// 2022-03-11       Jay             Add TicTacToe.cs class
// 2022-03-11       Jay             Add main string methods to TicTacToe class
// 2022-03-11       Jay             Create inBoard and displayBoard method
// 2022-03-11       Jay             Add description of each part of the program
// 2022-03-12       Jay             Re-check the codes and run the program
// 2022-03-12       Jay             Rebuild, debug, then testrun the program

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{   // main method for TicTacToe
    internal class TicTacToe
    {
        static int[,] board;
        string _playerName;

        public TicTacToe(int player, string playerName)
        {
            PlayerName = playerName;
            Player = player;
            board = new int[3, 3];
        }

        public int Player { get; set; }

        // input player's name
        public string PlayerName
        { 
            get { return _playerName; }
            set
            {
                if (value.Length > 0)
                    _playerName = value;
                else
                {
                    while (value.Length < 1) // method to enter new players name
                    {
                        Console.WriteLine("Please re-enter player's name: ");
                        value = Console.ReadLine();
                    }
                }
            }
        }

        public bool PlayGame()
        {
            int r = 0;
            int c = 0;
            Random rand1 = new Random();
            Random rand2 = new Random();

            if (PlayerName != "computer") // computer versus a human player
            {
                Console.WriteLine("ENTER where to place your symbol: ");
                int.TryParse(Console.ReadLine().Trim(), out r);
                int.TryParse(Console.ReadLine().Trim(), out c);
                // 0 0 0
                // 0 0 0
                // 0 0 0
            }
            else // player VS computer while playing
            {
                r = rand1.Next(1, 4);
                for (int i = 0; i < 5000; i++)
                c = rand2.Next(1, 4);
            }
            while (!checkBoard(r,c))
            {
                if (PlayerName != "computer")
                {
                    Console.WriteLine("Wrong coordinates, please try again: ");
                    int.TryParse(Console.ReadLine().Trim(), out r);
                    int.TryParse(Console.ReadLine().Trim(), out c);
                }
                else
                {
                    r = rand1.Next(1, 4);
                    for (int i = 0; i < 5000; i++)
                    c = rand2.Next(1, 4);
                }
            }

            board[r - 1, c - 1] = Player;
            // update
            displayBoard(); 

            // game when win method
            if (win())
            {
                if (PlayerName.Equals("computer"))
                    Console.WriteLine("Computer Win!");
                else
                    Console.WriteLine("Congratulations " + PlayerName + ", You Win!");
                // end of the game and winnner result   
                return true;
            }
            else if (tie())
            {
                Console.WriteLine("It's a TIE!");
                // end of the game and draw
                return true;
            }
            // if the result not a draw and resume game
            return false;
        }

        // draw method
        private bool tie()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (board[r, c] != 1 && board[r, c] != 2)
                        return false;
                }
            }
            return true;
        }

        // win method
        private bool win()
        {
            // check rows
            if (board[0, 0].Equals(Player) && board[0, 1].Equals(Player) && board[0, 2].Equals(Player))
                return true;
            if (board[1, 0].Equals(Player) && board[1, 1].Equals(Player) && board[1, 2].Equals(Player))
                return true;
            if (board[2, 0].Equals(Player) && board[2, 1].Equals(Player) && board[2, 2].Equals(Player))
                return true;

            // columns
            if (board[0, 0].Equals(Player) && board[1, 0].Equals(Player) && board[2, 0].Equals(Player))
                return true;
            if (board[0, 1].Equals(Player) && board[1, 1].Equals(Player) && board[2, 1].Equals(Player))
                return true;
            if (board[0, 2].Equals(Player) && board[1, 2].Equals(Player) && board[2, 2].Equals(Player))
                return true;

            // accross
            if (board[0, 0].Equals(Player) && board[1, 1].Equals(Player) && board[2, 2].Equals(Player))
                return true;
            if (board[0, 2].Equals(Player) && board[1, 1].Equals(Player) && board[2, 0].Equals(Player))
                return true;

            return false;
        }

        // checkBoard method
        private bool checkBoard(int r, int c)
        {
            bool OK = false;
            if (r > 3 || c > 3 || r < 1 || c < 1)
                return false;
            if (board[r - 1, c - 1] != 1 && board[r - 1, c - 1] != 2)
                OK = true;

            return OK;
        }
        // intBoard method
        public static void intBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                    board[r, c] = 0;
            }
            displayBoard();
        }

        // displayBoard method 
        private static void displayBoard()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                    Console.Write(board[r, c] + " ");

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
