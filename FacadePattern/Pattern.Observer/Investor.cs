using System;

namespace Pattern.Observer
{
    // Concrete Observer: responds to subject updates
    class Investor : IStockObserver
    {
        private string _name;

        public Investor(string name)
        {
            _name = name;
        }

        public void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"   [{_name}] Stock {stockSymbol} is now ${price:F2}. Making trading decision...");
        }
    }
}
