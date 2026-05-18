namespace Challenge2
{
    class CustomerUI
    {
        //--- show customer menu ---
        public static void ShowMenu(string customerName)
        {
            Customer customer = new Customer(customerName);
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("\n========= Customer Menu =========");
                Console.WriteLine("1. View All Products");
                Console.WriteLine("2. Buy Products");
                Console.WriteLine("3. Generate Invoice");
                Console.WriteLine("4. Exit");
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
                        ViewProducts();
                        Console.ReadKey();
                        break;
                    case 2:
                        BuyProduct(customer);
                        Console.ReadKey();
                        break;
                    case 3:
                        GenerateInvoice(customer);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            } while (choice != 4);
        }

        //--- display all products ---
        static void ViewProducts()
        {
            List<Product> list = ProductDL.GetAllProducts();
            if (list.Count == 0) { Console.WriteLine("No products available."); return; }

            Console.WriteLine($"\n{"#",-3} {"Name",-20} | {"Category",-10} | {"Price",7} | {"Stock",5}");
            Console.WriteLine(new string('-', 55));
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine($"{i + 1,-3} {list[i]}");
        }

        //--- buy a product and add to cart ---
        static void BuyProduct(Customer customer)
        {
            List<Product> list = ProductDL.GetAllProducts();
            if (list.Count == 0) { Console.WriteLine("No products available."); return; }

            ViewProducts();
            Console.Write("Enter product number to buy: ");
            if (!int.TryParse(Console.ReadLine(), out int idx)) { Console.WriteLine("Invalid input."); return; }
            idx--;

            if (idx < 0 || idx >= list.Count) { Console.WriteLine("Invalid selection."); return; }

            Product selected = list[idx];
            Console.Write($"Enter quantity (available: {selected.Stock}): ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0) { Console.WriteLine("Invalid quantity."); return; }

            if (qty > selected.Stock) { Console.WriteLine("Not enough stock!"); return; }

            selected.Stock -= qty;
            customer.AddToCart(selected, qty);
            Console.WriteLine($"Added {qty}x {selected.Name} to cart.");
        }

        //--- print invoice for customer ---
        static void GenerateInvoice(Customer customer)
        {
            if (customer.Cart.Count == 0) { Console.WriteLine("Your cart is empty."); return; }

            Console.WriteLine("\n=============================");
            Console.WriteLine("          INVOICE            ");
            Console.WriteLine("=============================");
            Console.WriteLine($"Customer: {customer.Name}");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"Product",-20} {"Qty",5} {"Unit+Tax",10} {"Subtotal",10}");
            Console.WriteLine(new string('-', 60));

            foreach (var item in customer.Cart)
            {
                double subtotal = item.product.GetPriceWithTax() * item.qty;
                Console.WriteLine($"{item.product.Name,-20} {item.qty,5} {item.product.GetPriceWithTax(),10:F2} {subtotal,10:F2}");
            }

            Console.WriteLine(new string('-', 60));
            Console.WriteLine($"{"TOTAL",-35} {customer.GetTotalBill(),15:F2}");
            Console.WriteLine("=============================");
            Console.WriteLine("(Prices include applicable tax)");
        }
    }
}