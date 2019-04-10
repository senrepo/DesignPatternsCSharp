using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class AbstractFactoryPattern
    {
        public static void Test()
        {
            SoapFactory factoryA = SoapFactoryA.Instance;
            SoapFactory factoryB = SoapFactoryB.Instance;

            MedicatedSoap medimex = factoryA.CreateMedicatedSoap();
            NonMedicatedSoap lux = factoryA.CreateNonMedicatedSoap();

            MedicatedSoap dettol = factoryB.CreateMedicatedSoap();
            NonMedicatedSoap dove = factoryB.CreateNonMedicatedSoap();

            Console.WriteLine(medimex.Name);
            Console.WriteLine(lux.Name);
            Console.WriteLine(dettol.Name);
            Console.WriteLine(dove.Name);

        }

    }

    //Create families of objects without using its concrete class
    //Create Medicated(Medimix from FactoryA, Dettol from FactoryB), NonMedicated Soaps (Lux from FactoryA, Dove from Factory B) from two different Soap Factories (FactoryA, FactoryB)


    //specification for any Medicated Soap
    public abstract class MedicatedSoap
    {
        public abstract string Name { get; set; }
        public abstract string Ingredients { get; set; }
        
    }

    //specification for any NonMedicated Soap
    public abstract class NonMedicatedSoap
    {
        public abstract string Name { get; set; }
        public abstract string Fragrance { get; set; }
    }


    //concreate specification of each soap product
    public class MediMix : MedicatedSoap
    {
        public override string Name {get; set; }
        public override string Ingredients {get; set;}

        public MediMix()
        {
            this.Name = "Medimex";
            this.Ingredients = "Coconut Oil, Ayurvedic Herbs";
        }

    }

    public class Dettol : MedicatedSoap
    {
        public override string Name {get; set; }
        public override string Ingredients {get; set;}

        public Dettol()
        {
            this.Name = "Dettol";
            this.Ingredients = "Antiseptic oils";
        }
    }

    public class Lux : NonMedicatedSoap
    {
        public override string Name {get; set; }
        public override string Fragrance {get; set;}

        public Lux()
        {
            this.Name = "Lux";
            this.Fragrance = "Lux Fragrance";
        }
    }

    public class Dove : NonMedicatedSoap
    {
        public override string Name {get; set; }
        public override string Fragrance {get; set;}

        public Dove()
        {
            this.Name = "Dove";
            this.Fragrance = "Dove Fragrance";
        }
    }


    //Government specifies set of process for any soap factory
    public abstract class SoapFactory
    {
        public abstract MedicatedSoap CreateMedicatedSoap();
        public abstract NonMedicatedSoap CreateNonMedicatedSoap();

    }


    //FactoryA produces only Medimix and Lux - Singleton class
    public class SoapFactoryA : SoapFactory
    {
        static readonly SoapFactoryA instance = new SoapFactoryA();

        private SoapFactoryA()
        {
        }

        public static SoapFactoryA Instance
        {
            get
            {
                return instance;
            }
        }
       
        public override MedicatedSoap CreateMedicatedSoap()
        {
            return new MediMix();
        }

        public override NonMedicatedSoap CreateNonMedicatedSoap()
        {
            return new Lux();
        }
    }

    //FactoryB produces only Dettol and Dove - Make it Singleton Class
    public class SoapFactoryB : SoapFactory
    {
        static readonly SoapFactoryB instance = new SoapFactoryB();

        private SoapFactoryB()
        {
        }

        public static SoapFactoryB Instance
        {
            get
            {
                return instance;
            }
        }        
        
        public override MedicatedSoap CreateMedicatedSoap()
        {
            return new Dettol();
        }

        public override NonMedicatedSoap CreateNonMedicatedSoap()
        {
            return new Dove();
        }
    }
}
