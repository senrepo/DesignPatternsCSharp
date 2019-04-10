using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class DecoratorPattern
    {
        public static void Test()
        {
            MediumPizza mediumPizza = new MediumPizza();
            PizzaDecorator pizzaDecorator = new OnionTopping(mediumPizza);
            pizzaDecorator = new MushroomTopping(pizzaDecorator);

            Console.WriteLine("Pizza price after added Toppings " + pizzaDecorator.GetPrice().ToString());
            
        }
    }

    //Decorator Pattern: Add responsibilities to objects dynamically
    //Example: Order Pizza and add toppings, the price is added as many toppings we add

    //All your pizzas will inherit from this BasePizza class to identify themselves as pizzas.
    public abstract class BasePizza
    {
        protected double myPrice;

        //This method will return the price of the pizza object.
        public virtual double GetPrice()
        {
            return this.myPrice;
        }
    }

    //All toppings will inherit from this ToppingsDecorator class to be able to be added to any pizza in the pizza-shop.
    public abstract class PizzaDecorator : BasePizza
    {
        //Each topping will need to know to which pizza it is being added to.
        protected BasePizza pizza;
        public PizzaDecorator(BasePizza pizzaToDecorate)
        {
            this.pizza = pizzaToDecorate;
        }

        //This method will return cumulative price of both pizza and the topping.
        public override double GetPrice()
        {
            return (this.pizza.GetPrice() + this.myPrice);
        }
    }

    public class MediumPizza : BasePizza
    {
        public MediumPizza()
        {
            this.myPrice = 6;
        }
    }

    public class LargePizza : BasePizza
    {
        public LargePizza()
        {
            this.myPrice = 7;
        }
    }

    public class OnionTopping : PizzaDecorator
    {
        public OnionTopping(BasePizza pizzaToDecorate)
            : base(pizzaToDecorate)
        {
            this.myPrice = 1;
        }
    }

    public class MushroomTopping : PizzaDecorator
    {
        public MushroomTopping(BasePizza pizzaToDecorate)
            : base(pizzaToDecorate)
        {
            this.myPrice = 1;
        }
    }
}
