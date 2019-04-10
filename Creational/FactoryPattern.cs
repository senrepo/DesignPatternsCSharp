using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class FactoryPattern
    {
        public static void Test()
        {
            Fruit apple = FruitStore.GetFruit("apple");
            Console.WriteLine("Apple color is  " + apple.FruitColor);

            Fruit orange = FruitStore.GetFruit("orange");
            Console.WriteLine("Apple color is  " + orange.FruitColor);
        }
    }

    //Factory Pattern - Creates an instance of several derived classes based on client choice
    //Example: Fruit store will provide different fruits based on user's choice

    public interface IFruit
    {
        string Taste { get; set; }
        string FruitColor { get; set; }
    }

    public abstract class Fruit : IFruit
    {
        public string Taste { get; set; }
        public abstract string FruitColor { get; set; }

        public Fruit()
        {
            Taste = "sweet";
        }
    }

    public class Apple : Fruit
    {
        private string fruitColor;

        public Apple()
        {
            FruitColor = "red";
        }

        public override string FruitColor
        {
            get
            {
                return fruitColor;
            }
            set
            {
                fruitColor = value;
            }
        }
    }

    public class Orange : Fruit
    {
        private string fruitColor;

        public Orange()
        {
            FruitColor = "orange";
        }

        public override string FruitColor
        {
            get
            {
                return fruitColor;
            }
            set
            {
                fruitColor = value;
            }
        }
    }

    public class FruitStore
    {
        private FruitStore()
        {
        }

        public static Fruit GetFruit(string type)
        {
            Fruit fruit;

            switch(type)
            {
               case "apple" : fruit = new Apple(); break;
               case "orange": fruit  = new Orange(); break;
               default: fruit = null; break;
            }

            return fruit;
        }

    }
}
