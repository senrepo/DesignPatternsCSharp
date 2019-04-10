using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class ObserverPattern
    {
        public static void Test()
        {
            Stock cognizantStock = new CTS(70.00);
            cognizantStock.Subscribe(new Invester("Jack"));
            cognizantStock.Subscribe(new Invester("Mark"));
            cognizantStock.Price = 80.00;
        }

    }

    //Observer Pattern: notify the changes to subscribers
    //Example: Notify the stock price changes to all investors of the stock

    abstract class Stock
    {
        public string Symbol { get; set; }
        private double price;

        private List<IInvester> investers = new List<IInvester>();


        public Stock(string symbol, double price)
        {
            Symbol = symbol;
            Price = price;
        }

        public void Subscribe(IInvester invester)
        {
            investers.Add(invester);
        }

        public void UnSubscribe(IInvester invester)
        {
            investers.Remove(invester);
        }

        public void Notify()
        {
            foreach (var invester in investers)
            {
                invester.Update(this);
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                Notify();
            }

        }
    }

    class CTS : Stock
    {
        public CTS(double price) : base("CTSH", price)
        {
        }
    }

    interface IInvester
    {
        void Update(Stock stock);
    }

    class Invester : IInvester
    {
        protected string name;

        public Invester(string name)
        {
            this.name = name;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine("Notified {0} of {1}'s " + "change to {2:C}", name, stock.Symbol, stock.Price);
        }
    }


}
