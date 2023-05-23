// Jay Bai
// Cs3Apps
// TINFO-200

////////////////////////////////////////////////////////////////////////////////////////////////
// Change History
// Date             Developer       Description of change
// 2022-03-11       Jay             Create file
// 2022-03-11       Jay             Add main string methods
// 2022-03-11       Jay             Add description of each part of the program
// 2022-03-11       Jay             Re-check the codes and run the program
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class Program
    {
        public static bool[] seats;
        public static int totalReserveFirstClass;
        public static int totalReserveEconomyClass;
        static void Main(string[] args)
        {
            // seating chart 
            seats = new bool [11];
            int selectedClass = 0;

            for (int i = 0; i <= 10; i++)
                seats[i] = false;

            for (int i = 1; i <= 10; i++)
            {
                // greet the user
                Console.WriteLine("Welcome to Airline Reservations System!");
                // user menu selection options
                Console.WriteLine("ENTER 1 to reserve First Class seat or 2 to reserve Economy Class seat.");
                selectedClass = Convert.ToInt32(Console.ReadLine());

                while (selectedClass < 1 || selectedClass > 2)
                {
                    Console.WriteLine("PRESS ONLY 1 to reserve First Class seat or 2 to reserve Economy Class seat.");
                    selectedClass = Convert.ToInt32(Console.ReadLine());
                }
                if (selectedClass == 1)
                {
                   if (totalReserveFirstClass == 5 && totalReserveEconomyClass < 5)
                   {
                        Console.WriteLine("Unfortunately, First Class seats isn't available at this time. Book a Economy Class seat instead? Y / N");
                        if (Console.ReadLine().Equals("N"))
                        {
                            Console.WriteLine("Next flight leaves in 3 hours.");
                            i--;
                        }
                        else
                        {
                            reserveEconomyClass();
                        }
                   }
                   else if (totalReserveFirstClass < 5)
                   {
                        reserveFirstClass();
                   }
                    //totalReserveFirstClass();
                }
                else
                {
                    if (totalReserveEconomyClass == 5 && totalReserveFirstClass < 5)
                    {
                        Console.WriteLine("Unfortunately, Economy Class seats isn't available at this time. Book a First Class seat instead? Y / N");
                        if (Console.ReadLine().Equals("N"))
                        {
                            Console.WriteLine("Next flight leaves in 3 hours.");
                            i--;
                        }
                        else
                        {
                            reserveFirstClass();
                        }
                    }
                    else
                    {
                        reserveEconomyClass();
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Unfortunately, current airplane is fully occupied. Next flight leaves in 3 hours.");
            Console.WriteLine();
        }
        // reserve selected first class seat 
        public static void reserveFirstClass()
        {
                bool noDuplicate = false;
                Random rand = new Random();
                int index = 0;
            // generating the first class seat number
            while (!noDuplicate)
            {
                    noDuplicate = true;
                    index = rand.Next(1, 6);
                    if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totalReserveFirstClass++;
            Console.WriteLine("Assigned seat {0:N0}", index);
        }

        // reserve selected economy class seat
        public static void reserveEconomyClass()
        {
            bool noDuplicate = false;
            Random rand = new Random();
            int index = 0;
            // generating the economy class seat number
            while (!noDuplicate)
            {
                noDuplicate = true;
                index = rand.Next(6, 11);
                if (seats[index] == true)
                    noDuplicate = false;
            }
            seats[index] = true;
            totalReserveEconomyClass++;
            Console.WriteLine("Assigned seat {0:N0}", index);
        }
    }
}
