using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class FacadePattern
    {
        public static void Test()
        {
            new ComputerStore().Order();
        }
    }

    //Facade Pattern - providing simplificed interface to overall functioality of the complex system

    public class ComputerStore
    {
        public void Order()
        {
            new OrderFulfillment().MakeOrder();
            new Billing().MakeBill();
            new Shipping().ShipItems();
        }
    }

    public class OrderFulfillment
    {
        public void MakeOrder()
        {
            Console.WriteLine("Computer is ordered");
        }
    }

    public class Billing
    {
        public void MakeBill()
        {
            Console.WriteLine("Amout Charged from customer");
        }

    }

    public class Shipping
    {
        public void ShipItems()
        {
            Console.WriteLine("Computer shipped to customer address");
        }
    }
}
