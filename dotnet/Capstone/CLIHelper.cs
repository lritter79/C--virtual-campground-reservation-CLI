using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    //helper for getting input from the user, takes in a string of what to display and returns therequested data type
    public static class CLIHelper
    {
        public static DateTime GetDateTime(string message)
        {
            string userInput = String.Empty;
            DateTime dateValue = DateTime.MinValue;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid date format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!DateTime.TryParse(userInput, out dateValue));

            return dateValue;
        }

        public static int GetInteger(string message)
        {
            string userInput = String.Empty;
            int intValue = -1;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!int.TryParse(userInput, out intValue) || intValue <0);

            return intValue;

        }

        public static string GetString(string message)
        {
            string userInput = String.Empty;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (String.IsNullOrEmpty(userInput));

            return userInput;
        }

        public static double GetDouble(string message)
        {
            string userInput = String.Empty;
            double doubleValue = 0.0;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!double.TryParse(userInput, out doubleValue));

            return doubleValue;
        }

        public static decimal GetDecimal(string message)
        {
            string userInput = String.Empty;
            decimal decimalValue = 0.0m;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!decimal.TryParse(userInput,out decimalValue));

            return decimalValue;
        }

        public static bool GetBool(string message)
        {
            string userInput = String.Empty;
            bool boolValue = false;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (!bool.TryParse(userInput, out boolValue));

            return boolValue;
        }

        //returns and array of two dates with the second being after the first
        public static DateTime[] GetDateRange(string firstMessage, string secondMessage)
        {
            string input = "";
            DateTime[] dateRange = new DateTime[2];

            int numberOfAttempts = 0;
            bool done = false;

            while (!done)
            {


                do
                {
                    if (numberOfAttempts > 0)
                    {
                        Console.WriteLine("Invalid input format. Please try again\n");
                    }

                    Console.Write(firstMessage + " ");
                    input = Console.ReadLine();
                    numberOfAttempts++;
                }
                while (!DateTime.TryParse(input, out dateRange[0]));

                numberOfAttempts = 0;

                do
                {
                    if (numberOfAttempts > 0)
                    {
                        Console.WriteLine("\nInvalid input  Please try again\n");
                    }

                    Console.Write(secondMessage + " ");
                    input = Console.ReadLine();
                    numberOfAttempts++;
                }
                while (!DateTime.TryParse(input, out dateRange[1]));

                if(dateRange[0] < DateTime.Now || dateRange[1] < DateTime.Now || dateRange[1] < dateRange[0])
                {
                    Console.WriteLine("\nCannot Time Travel to the past! If you figure it out, teach me please!!");
                }


                else if(dateRange[0] < dateRange[1])
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine("\nEnd date cannot be before Start Date, please try again.\n");
                }
            }




            return dateRange;
        }

        public static string GetYesOrNo(string message)
        {
            string userInput = String.Empty;
            int numberOfAttempts = 0;

            do
            {
                if (numberOfAttempts > 0)
                {
                    Console.WriteLine("Invalid input format. Please try again");
                }

                Console.Write(message + " ");
                userInput = Console.ReadLine();
                numberOfAttempts++;
            }
            while (String.IsNullOrEmpty(userInput) || (!userInput.ToLower().StartsWith("y") && !userInput.ToLower().StartsWith("n")));

            return userInput;
        }
    }
}
