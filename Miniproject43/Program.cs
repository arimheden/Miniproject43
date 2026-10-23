namespace Miniproject43.ProductList;
using ProductList;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                
                // Perform product sort and display
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

                // Perform product search
                case "3":
                    Console.WriteLine("Searching products");

                    // Request user input
                    string searchString = prodList.searchInput();

                    Console.WriteLine();
                    Console.WriteLine("Matching products...");
                    Console.WriteLine();

                    products.ForEach(delegate (string thisProduct)
                    {
                        if (thisProduct.Contains(searchString)) {
                            Console.WriteLine(thisProduct);
                        }
                    });
                    break;

                // Delete product from list
                case "4":
                    Console.WriteLine();

                    // Request user input
                    string deleteString = prodList.deleteInput();

                    // Validate user input
                    if (prodList.validateInput(deleteString))
                    {
                        // Remove product from list
                        products.RemoveAll(x => x ==  deleteString);
                    }
                    break;

                // Show statistics
                case "5":
                    Console.WriteLine("Statistics:");
                    prodList.productStatistics(products);
                    break;

                // Save product list and exit program
                case "6":
                    StreamWriter sw = new StreamWriter("products.json");
                    var jsonProductList = JsonSerializer.Serialize(products);
                    sw.Write(jsonProductList.ToString());
                    sw.Close();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

