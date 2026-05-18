namespace Challenge2
{
    class Customer
    {
        //--- properties ---
        public string Name { get; set; }
        public List<(Product product, int qty)> Cart { get; set; }

        //--- constructor ---
        public Customer(string name)
        {
            Name = name;
            Cart = new List<(Product, int)>();
        }

        //--- add product to cart ---
        public void AddToCart(Product p, int qty)
        {
            Cart.Add((p, qty));
        }

        //--- calculate total bill with tax ---
        public double GetTotalBill()
        {
            double total = 0;
            foreach (var item in Cart)
                total += item.product.GetPriceWithTax() * item.qty;
            return total;
        }
    }
}