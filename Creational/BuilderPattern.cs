using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class BuilderPattern
    {
        public static void Test()
        {
            //ordering HamBurger
            MealBuilder hamBurgerCrew = new HamBurgerCrew();
            Cashier counterMan = new Cashier(hamBurgerCrew);
            counterMan.constructMeal();
            Console.WriteLine(counterMan.getMeal());


            //ordering ChickenBurger
            MealBuilder chickenBurgerCrew = new ChickenBurgerCrew();
            counterMan = new Cashier(chickenBurgerCrew);
            counterMan.constructMeal();
            Console.WriteLine(counterMan.getMeal());
        }
    }


    //Separates object construction from its representation


    //product interface
    public class Meal
    {
        public string Drink { get; set; }
        public string MainCourse { get; set; }
        public string Side { get; set; }
    }

    //restaurant crew
    public interface MealBuilder
    {
        void buildMainCourse();
        void buildDrink();
        void buildSideItems();
        string getMeal();
    }

    //ham burger crew 
    public class HamBurgerCrew : MealBuilder
    {
        private Meal meal;

        public HamBurgerCrew()
        {
            meal = new Meal();
        }

        #region MealBuilder Members

        public void buildMainCourse()
        {
            meal.MainCourse = "ham patty";
        }

        public void buildDrink()
        {
            meal.Drink = "any soda";
        }

        public void buildSideItems()
        {
            meal.Side = "fries";
        }

        public string getMeal()
        {
            return "drink:" + meal.Drink + ", main course:" + meal.MainCourse + ",side:" + meal.Side;
        }

        #endregion
    }

    //chicken burger crew 
    public class ChickenBurgerCrew : MealBuilder
    {
        private Meal meal;
        public ChickenBurgerCrew()
        {
            meal = new Meal();
        }

        #region MealBuilder Members

        public void buildMainCourse()
        {
            meal.MainCourse = "chicken patty";
        }

        public void buildDrink()
        {
            meal.Drink = "any soda";
        }

        public void buildSideItems()
        {
            meal.Side = "fries";
        }

        public string getMeal()
        {
            return "drink:" + meal.Drink + ", main course:" + meal.MainCourse + ",side:" + meal.Side;
        }

        #endregion
    }

    //Director
    public class Cashier
    {
        private MealBuilder mealBuilder = null;

        public Cashier(MealBuilder builder)
        {
            mealBuilder = builder;
        }

        public void constructMeal()
        {
            mealBuilder.buildMainCourse();
            mealBuilder.buildDrink();
            mealBuilder.buildDrink();
        }

        public string getMeal()
        {
            return mealBuilder.getMeal();
        }
    }
}
