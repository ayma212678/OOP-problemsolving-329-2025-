namespace Challenge2
{
    class Product
    {
        //--- properties ---
        public string Name { get; set; }
        public string Category { get; set; }  //--- "Grocery", "Fruit", or other ---
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Threshold { get; set; }

        //--- constructor ---
        public Product(string name, string category, double price, int stock, int threshold)
        {
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
            Threshold = threshold;
        }

        //--- tax rate based on category ---
        public double GetTaxRate()
        {
            if (Category.ToLower() == "grocery") return 0.10;
            if (Category.ToLower() == "fruit") return 0.05;
            return 0.15;
        }

        //--- price including tax ---
        public double GetPriceWithTax()
        {
            return Price + (Price * GetTaxRate());
        }

        //--- check if stock is below threshold ---
        public bool NeedsReorder()
        {
            return Stock < Threshold;
        }

        public override string ToString()
        {
            return $"{Name,-20} | {Category,-10} | Price: {Price,7:F2} | Stock: {Stock,4} | Threshold: {Threshold}";
        }
    }
}