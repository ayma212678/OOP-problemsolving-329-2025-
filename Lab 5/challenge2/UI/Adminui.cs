namespace Challenge2
{
    class AdminUI
    {
        //--- show admin menu ---
        public static void ShowMenu()
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("\n========= Admin Menu =========");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Find Product with Highest Unit Price");
                Console.WriteLine("4. View Sales Tax of All Products");
                Console.WriteLine("5. Products to be Ordered (below threshold)");
                Console.WriteLine("6. Exit");
                Console.Write("Enter choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Press any key to try again.");
                    Console.ReadKey();
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddProduct();
                        Console.ReadKey();
                        break;
                    case 2:
                        ViewAllProducts();
                        Console.ReadKey();
                        break;
                    case 3:
                        HighestPriceProduct();
                        Console.ReadKey();
                        break;
                    case 4:
                        ViewSalesTax();
                        Console.ReadKey();
                        break;
                    case 5:
                        ProductsToOrder();
                        Console.ReadKey();
                        break;
                    case 6:
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            } while (choice != 6);
        }

        //--- add a new product ---
        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Name cannot be empty."); return; }

            Console.Write("Enter category (Grocery / Fruit / Other): ");
            string cat = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(cat)) { Console.WriteLine("Category cannot be empty."); return; }

            Console.Write("Enter price: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price < 0) { Console.WriteLine("Invalid price."); return; }

            Console.Write("Enter stock quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int stock) || stock < 0) { Console.WriteLine("Invalid stock."); return; }

            Console.Write("Enter minimum threshold: ");
            if (!int.TryParse(Console.ReadLine(), out int threshold) || threshold < 0) { Console.WriteLine("Invalid threshold."); return; }

            Product p = new Product(name, cat, price, stock, threshold);
            ProductDL.AddProduct(p);
            Console.WriteLine("Product added successfully!");
        }

        //--- display all products ---
        static void ViewAllProducts()
        {
            List<Product> list = ProductDL.GetAllProducts();
            if (list.Count == 0) { Console.WriteLine("No products found."); return; }

            Console.WriteLine($"\n{"Name",-20} | {"Category",-10} | {"Price",7} | {"Stock",5} | {"Threshold"}");
            Console.WriteLine(new string('-', 65));
            foreach (Product p in list)
                Console.WriteLine(p);
        }

        //--- find product with highest price ---
        static void HighestPriceProduct()
        {
            Product p = ProductDL.GetHighestPriceProduct();
            if (p == null) { Console.WriteLine("No products found."); return; }
            Console.WriteLine($"\nHighest Price Product:\n{p}");
        }

        //--- view sales tax for all products ---
        static void ViewSalesTax()
        {
            List<Product> list = ProductDL.GetAllProducts();
            if (list.Count == 0) { Console.WriteLine("No products found."); return; }

            Console.WriteLine($"\n{"Name",-20} | {"Category",-10} | {"Price",7} | {"Tax%",5} | {"Price+Tax",10}");
            Console.WriteLine(new string('-', 70));
            foreach (Product p in list)
                Console.WriteLine($"{p.Name,-20} | {p.Category,-10} | {p.Price,7:F2} | {p.GetTaxRate() * 100,4:F0}% | {p.GetPriceWithTax(),10:F2}");
        }

        //--- show products that need restocking ---
        static void ProductsToOrder()
        {
            List<Product> list = ProductDL.GetProductsToReorder();
            if (list.Count == 0) { Console.WriteLine("All products are sufficiently stocked."); return; }

            Console.WriteLine("\nProducts that need to be reordered:");
            foreach (Product p in list)
                Console.WriteLine(p);
        }
    }
}