using System;

namespace Pattern.Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Observer Pattern: Stock Price Notification System ===\n");

            // Create a subject (stock price tracker)
            StockPrice appleStock = new StockPrice("AAPL", 150.00m);

            // Create observers (investors)
            Investor investor1 = new Investor("Alice");
            Investor investor2 = new Investor("Bob");
            Investor investor3 = new Investor("Charlie");

            Console.WriteLine("--- Attaching observers ---");
            appleStock.Attach(investor1);
            appleStock.Attach(investor2);
            appleStock.Attach(investor3);

            Console.WriteLine("\n--- Stock price changes ---");
            appleStock.SetPrice(155.50m);

            Console.WriteLine("\n--- Detaching Bob, then changing price again ---");
            appleStock.Detach(investor2);
            appleStock.SetPrice(152.25m);

            Console.WriteLine("\n--- Re-attaching Bob ---");
            appleStock.Attach(investor2);
            appleStock.SetPrice(158.75m);

            Console.WriteLine("\n--- Price update with no change ---");
            appleStock.SetPrice(158.75m);

            Console.WriteLine("\n\n=== Key Takeaways ===");
            Console.WriteLine("✓ Subject (StockPrice) doesn't know or depend on observers");
            Console.WriteLine("✓ Observers (Investors) are notified automatically of changes");
            Console.WriteLine("✓ Loose coupling: observers can attach/detach dynamically");
            Console.WriteLine("✓ One-to-many relationship: one stock notifies many investors");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
