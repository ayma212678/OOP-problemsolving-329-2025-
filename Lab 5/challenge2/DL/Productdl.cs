namespace Challenge2
{
    class ProductDL
    {
        //--- in-memory product storage ---
        private static List<Product> products = new List<Product>();

        //--- add a new product ---
        public static void AddProduct(Product p)
        {
            products.Add(p);
        }

        //--- get all products ---
        public static List<Product> GetAllProducts()
        {
            return products;
        }

        //--- find product with highest price ---
        public static Product GetHighestPriceProduct()
        {
            if (products.Count == 0) return null;
            Product max = products[0];
            foreach (Product p in products)
                if (p.Price > max.Price) max = p;
            return max;
        }

        //--- get products that need restocking ---
        public static List<Product> GetProductsToReorder()
        {
            List<Product> list = new List<Product>();
            foreach (Product p in products)
                if (p.NeedsReorder()) list.Add(p);
            return list;
        }
    }
}