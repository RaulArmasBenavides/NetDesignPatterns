using System;
using System.Collections.Generic;

namespace Pattern.Observer
{
    // Subject: manages observers and notifies them of changes
    class StockPrice
    {
        private string _symbol;
        private decimal _price;
        private List<IStockObserver> _observers = new List<IStockObserver>();

        public StockPrice(string symbol, decimal initialPrice)
        {
            _symbol = symbol;
            _price = initialPrice;
        }

        // Attach an observer to this subject
        public void Attach(IStockObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                Console.WriteLine($"[StockPrice] Observer attached to {_symbol}");
            }
        }

        // Detach an observer from this subject
        public void Detach(IStockObserver observer)
        {
            if (_observers.Contains(observer))
            {
                _observers.Remove(observer);
                Console.WriteLine($"[StockPrice] Observer detached from {_symbol}");
            }
        }

        // Notify all observers of a price change
        private void Notify()
        {
            Console.WriteLine($"\n[StockPrice] Notifying {_observers.Count} observer(s) about {_symbol} change...\n");
            foreach (var observer in _observers)
            {
                observer.Update(_symbol, _price);
            }
        }

        // Update price and trigger notifications
        public void SetPrice(decimal newPrice)
        {
            if (newPrice != _price)
            {
                Console.WriteLine($">>> Price of {_symbol} changed from ${_price:F2} to ${newPrice:F2}");
                _price = newPrice;
                Notify();
            }
            else
            {
                Console.WriteLine($">>> Price of {_symbol} unchanged (${_price:F2})");
            }
        }

        public decimal GetPrice()
        {
            return _price;
        }

        public string GetSymbol()
        {
            return _symbol;
        }
    }
}
