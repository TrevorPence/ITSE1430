/*
 * Course: ITSE 1430 20630
 * Created By: Trevor Pence
 * 9/18/2017
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    class Program
    {
        static string title = null;
        static string description = null;
        static int length = 0;
        static bool owned = false;

        static void Main(string[] args)
        {
            DisplayMenu();
        }

        static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("1) List Movie.");
                Console.WriteLine("2) Add Movie.");
                Console.WriteLine("3) Remove Movie.");
                Console.WriteLine("4) Quit.");
                string input = Console.ReadLine();

                if (input.Length > 0)
                {
                    switch (input[0])
                    {
                        case '1': ListMovie(); break;
                        case '2': AddMovie(); break;
                        case '3': RemoveMovie(); break;
                        case '4': return;
                        default: Console.WriteLine("Invalid input try again."); break;
                    }
                }
                Console.Clear();
            }
        }

        static void ListMovie()
        {
            if(String.IsNullOrEmpty(title))
            {
                Console.WriteLine("\nNo movies available.");
            }
            else
            {
                Console.WriteLine($"\n{title}");
                Console.WriteLine($"Description: {description}");
                Console.WriteLine($"Run Time: {length} minutes");
                Console.WriteLine($"Status: {(owned ? "Owned" : "Available")}");
            }

            Console.Write("\nPress any key to continue");
            Console.ReadKey();
        }

        static void AddMovie()
        {
            Console.Write("\nEnter a movie title: ");
            do
            {
                title = Console.ReadLine();
                if (String.IsNullOrEmpty(title))
                    Console.Write("Invalid input, must enter something for the title: ");
            } while (String.IsNullOrEmpty(title));

            Console.Write("Enter an optional description: ");
            description = Console.ReadLine();
            if (String.IsNullOrEmpty(description))
                description = "Not Available";

            Console.Write("Enter the movie's length: ");
            do
            {
                length = ReadInt();
                if (length < 0)
                    Console.Write("Invalid input, must be a number greater than 0: ");
            } while (length < 0);

            string readBool = null;
            Console.Write("Is the movie available (Y/N): ");
            do
            {
                readBool = Console.ReadLine();
                if (String.IsNullOrEmpty(readBool)) readBool = " ";
                if (Char.ToUpper(readBool[0]) != 'Y' && Char.ToUpper(readBool[0]) != 'N')
                    Console.Write("Must enter a Y(yes) or N(No): ");
            } while (Char.ToUpper(readBool[0]) != 'Y' && Char.ToUpper(readBool[0]) != 'N');

            if (Char.ToUpper(readBool[0]) == 'Y')
                owned = false;
            else
                owned = true;
        }

        static void RemoveMovie()
        {
            if (!String.IsNullOrEmpty(title))
            {
                string removeInput = null;
                Console.Write("Are you sure you want to delete the movie(Y/N): ");

                do
                {
                    removeInput = Console.ReadLine();
                    if (String.IsNullOrEmpty(removeInput)) removeInput = " ";
                    if (Char.ToUpper(removeInput[0]) != 'Y' && Char.ToUpper(removeInput[0]) != 'N')
                        Console.Write("Invalid input, enter Y(yes) or N(no): ");
                } while (Char.ToUpper(removeInput[0]) != 'Y' && Char.ToUpper(removeInput[0]) != 'N');

                if (Char.ToUpper(removeInput[0]) == 'Y')
                {
                    title = null;
                    length = 0;
                    description = null;

                    Console.WriteLine("Movie has been deleted, press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Movie has NOT been deleted, press any key to continue");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Write("\nThere are no movies to delete, enter any key to continue");
                Console.ReadKey();
            }
        }

        static int ReadInt()
        {
            string temp = null;
            temp = Console.ReadLine();
            if (Int32.TryParse(temp, out int result))
                return result;

            return -1;
        }
    }
}
