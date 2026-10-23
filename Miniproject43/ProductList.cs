using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Miniproject43
{
    /* 
     * Helper class for product list management
     * 
     */
    public class productListTools
    {
        // Request user input for product name
        public String productInput()
        {
            Console.Write("Product: ");
            string userInput = Console.ReadLine();
            userInput = userInput.Trim().ToUpper();
            return userInput;
        }

        // Request user input for product search
        public String searchInput()
        {
            Console.Write("Search for: ");
            string userInput = Console.ReadLine();
            userInput = userInput.Trim().ToUpper();
            return userInput;
        }

        // Validate user input for product name
        public bool validateInput(string inputToValidate)
        {
            if (String.IsNullOrEmpty(inputToValidate))
            {
                Console.WriteLine("Input cannot be empty");
                Console.WriteLine();
                return false;
            }

            if (!inputToValidate.Contains('-'))
            {
                Console.WriteLine("Product must contain a dash (-)");
                Console.WriteLine();
                return false;
            }

            // Validate left side of product name...
            string[] parts = inputToValidate.Split('-');
            if (!Regex.IsMatch(parts[0], @"^[A-Z]+\z"))
            {
                Console.WriteLine("The left side must contain letters only.");
                Console.WriteLine();
                return false;
            }

            // Validate right side of product name...'
            int productNumber;
            bool outOfRange = false;
            if (Int32.TryParse(parts[1], out productNumber))
            {
                if (productNumber < 200) outOfRange = true;
                else if (productNumber > 500) outOfRange = true;
                if (outOfRange)
                {
                    Console.WriteLine("The number part must be between 200 and 500");
                    Console.WriteLine();
                    return false;
                }
            }
            else
            {
                Console.WriteLine("The right side must contain numbers only.");
                Console.WriteLine();
                return false;
            }
            return true;
        }

        // Display menu and wait for key press
        public string productListMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View Products");
            Console.WriteLine("3. Search Product");
            Console.WriteLine("4. Delete Product");
            Console.WriteLine("5. Exit");
            Console.WriteLine();

            ConsoleKeyInfo keypressed;
            string numKey;
            do
            {
                keypressed = Console.ReadKey(true);
                numKey = keypressed.Key.ToString().Trim('D');

            } while (!Regex.IsMatch(numKey, @"^[1-5]+\z"));
            return numKey;
        }
    }
}




