// Jay Bai
// Cs3Apps
// TINFO-200

////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-03-11       Jay             Create file
// 2022-03-11       Jay             Add main string methods
// 2022-03-11       Jay             Add description of each part of the program
// 2022-03-11       Jay             Rebuild the program
// 2022-03-12       Jay             Change While(couter < 4) to While(couter < 5)
// 2022-03-12       Jay             Final test run
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elimination
{
    // main method for Elimination 
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            bool numberIn = false;
            int counter = 0;
            int[] numbers = new int[5];

            // method to enter the number between 10 to 100
            while (counter < 5)
            {
                numberIn = false;
                Console.WriteLine($"ENTER a number between 10 - 100");
                number = Convert.ToInt32(Console.ReadLine());

                while (number < 10 || number > 100)
                {
                    Console.WriteLine($"ENTER a number between 10 - 100");
                    number = Convert.ToInt32(Console.ReadLine());
                }
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (number == numbers[i])
                        numberIn = true;
                }
                if (!numberIn)
                        numbers[counter] = number;

                // distinct Elements output
                Console.Write("Distinct Elements: ");
                foreach (var e in numbers)
                {
                    if (e >= 10)
                        Console.Write(e + " ");
                }

                Console.WriteLine();

                counter++;
            }
            // end
            Console.ReadLine();
        }
    }
}
