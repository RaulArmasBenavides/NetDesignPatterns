using System;

namespace Pattern.Observer
{
    // Observer interface: defines what an observer must implement
    interface IStockObserver
    {
        void Update(string stockSymbol, decimal price);
    }
}
