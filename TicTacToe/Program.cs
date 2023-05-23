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
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string playerName = "";
            bool gameOver = false;

            // create players
            Console.WriteLine("Enter player 1's name: ");
            playerName = Console.ReadLine();
            TicTacToe player1 = new TicTacToe(1, playerName);
            Console.WriteLine("Enter player 2's name: (Type 'computer' to play with a computer)");
            playerName = Console.ReadLine();
            TicTacToe player2 = new TicTacToe(2, playerName);

            // method to end the game
            while (!gameOver)
            {
                TicTacToe.intBoard();
                while (!player1.PlayGame() && !player2.PlayGame())
                    gameOver = true;

                if (gameOver)
                {
                    Console.WriteLine("Do you want to play another game? Press [esc] to quit this game");
                    if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                        Console.WriteLine("See you next time!");
                    else
                        gameOver = false;
                }
            }
            // end
            Console.ReadLine();
        }
    }
}
