using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class MementoPattern
    {
        public static void Test()
        {
            SalesProspect prospect = new SalesProspect();
            prospect.Name = "Jack";
            prospect.Budget = 1000;
            Memento memento = prospect.SaveMemento();

            prospect.Name = "mark";
            prospect.Budget = 2000;

            prospect.RestoreMemento(memento);
            Console.WriteLine("Name " + prospect.Name);
            Console.WriteLine("Budget " + prospect.Budget);
        }
    }

    //Memento Patten: Save the object internal state (Undo the changes)

    class SalesProspect
    {
        public string Name { get; set; }
        public double Budget { get; set; }
        public Memento SaveMemento()
        {
            Console.WriteLine("\nSaving state --\n");
            return new Memento(Name, Budget);
        }
        // Restores memento
        public void RestoreMemento(Memento memento)
        {
            Console.WriteLine("\nRestoring state --\n");
            this.Name = memento.Name;
            this.Budget = memento.Budget;
        }
    }

    class Memento
    {
        public string Name { get; set; }
        public double Budget { get; set; }
        public Memento(string name, double budget)
        {
            Name = name;
            Budget = budget;
        }
    }
}
