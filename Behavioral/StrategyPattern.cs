using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class StrategyPattern
    {
        public static void Test()
        {
            TrasportationToAirport meGingoAirport = new TrasportationToAirport(new PersonalCar());
            TrasportationToAirport jackGoingAirport = new TrasportationToAirport(new Taxi());
            TrasportationToAirport markGoingAirport = new TrasportationToAirport(new CityBus());

            meGingoAirport.Go();
            jackGoingAirport.Go();
            markGoingAirport.Go();

        }
    }

    //Strategy Pattern - Declare methods in Interface but method implementations can vary in the derived class
    //Example: Modes of transportation to an airport - either go by personal car or taxi or city bus.
    //Different Sorting algorithams like Bubble Sort, Merge Sort, Quick Sort. The Sort Interface has a 'Sort' method declaration but each Sorting class has its own logic
    
    
    public interface ITravelMode
    {
        void MoveOn();
    }

    public class PersonalCar : ITravelMode
    {
        public void MoveOn()
        {
            Console.WriteLine("Drive by Car");
        }
    }

    public class Taxi : ITravelMode
    {
        public void MoveOn()
        {
            Console.WriteLine("Go by Taxi");
        }
    }

    public class CityBus : ITravelMode
    {
        public void MoveOn()
        {
            Console.WriteLine("Go by City Bus");
        }
    }

    public class TrasportationToAirport
    {
        private ITravelMode travelMode;

        public TrasportationToAirport(ITravelMode travelMode)
        {
            this.travelMode = travelMode;
        }

        public void Go()
        {
            travelMode.MoveOn();
        }
    }
}
