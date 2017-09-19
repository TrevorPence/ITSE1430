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
        /*
         * Gave me a warning telling me to put a "s_" at the beginning of my
         * variable names and I'm not sure why.
         */
        static string s_title;
        static string s_description;
        static int s_length;
        static bool s_owned;

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
            if(String.IsNullOrEmpty(s_title))
            {
                Console.WriteLine("\nNo movies available.");
            }
            else
            {
                Console.WriteLine($"\n{s_title}");
                Console.WriteLine($"Description: {s_description}");
                Console.WriteLine($"Run Time: {s_length} minutes");
                Console.WriteLine($"Status: {(s_owned ? "Owned" : "Available")}");
            }

            Console.Write("\nPress any key to continue");
            Console.ReadKey();
        }

        static void AddMovie()
        {
            Console.Write("\nEnter a movie title: ");
            do
            {
                s_title = Console.ReadLine();
                if (String.IsNullOrEmpty(s_title))
                    Console.Write("Invalid input, must enter something for the title: ");
            } while (String.IsNullOrEmpty(s_title));

            Console.Write("Enter an optional description: ");
            s_description = Console.ReadLine();
            if (String.IsNullOrEmpty(s_description))
                s_description = "Not Available";

            Console.Write("Enter the movie's length: ");
            do
            {
                s_length = ReadInt();
                if (s_length < 0)
                    Console.Write("Invalid input, must be a number greater than 0: ");
            } while (s_length < 0);

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
                s_owned = false;
            else
                s_owned = true;
        }

        static void RemoveMovie()
        {
            if (!String.IsNullOrEmpty(s_title))
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
                    s_title = null;
                    s_length = 0;
                    s_description = null;

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
