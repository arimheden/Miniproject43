namespace Miniproject43.ProductList;
using ProductList;

class Program
{
    static void Main(string[] args)
    {
        // Display instructions
        Console.WriteLine("----------------------------------");
        Console.WriteLine("PRODUCT LIST MANAGER - LEVEL 4");
        Console.WriteLine("----------------------------------");
        Console.WriteLine();

        // Initialize list
        List<string> products = new List<string>();

        // Initialize helper class'
        productListTools prodList = new productListTools();

        while (true)
        {

            string menuOption = prodList.productListMenu();

            switch (menuOption)
            {
                case "1":
                    // Adding products
                    Console.WriteLine("Enter product names.");
                    Console.WriteLine("Type 'exit' to finish.");
                    Console.WriteLine();
                    while (true)
                    {
                        // Request user input
                        string prodName = prodList.productInput();

                        // Terminate execution on "exit"
                        if (prodName == "EXIT")
                        {
                            break;
                        }

                        // Validate user input
                        bool checkValid = prodList.validateInput(prodName);

                        // Check for duplicate
                        if (products.Contains(prodName))
                        {
                            Console.WriteLine("The product already exists.");
                            Console.WriteLine();
                        }
                        else
                        {
                            // Add product if input is valid and not a duplicate
                            if (checkValid)
                            {
                                products.Add(prodName);
                            }
                        }
                    }
                    break;

                case "2":
                    Console.WriteLine();
                    Console.WriteLine("Sorted product list:");
                    Console.WriteLine();
                    products.Sort();
                    foreach (string product in products)
                    {
                        Console.WriteLine("-" + product);
                    }
                    break;

                case "3":
                    Console.WriteLine("Searching products");
                    break;

                case "4":
                    Console.WriteLine("Deleting products");
                    break;

                case "5":
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

