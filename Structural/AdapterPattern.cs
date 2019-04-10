using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class AdapterPattern
    {
        public static void Test()
        {
            HomePowerSupply powerSupply = new CellPhonePowerSupplyAdapter();
            powerSupply.InputAlternateCurrent();

        }
    }

    //Target class
    public class HomePowerSupply 
    {
        public virtual void InputAlternateCurrent()
        {

        }
    }

    //Adaptee class
    public class CellPhone
    {
        public string Model { get; set; }

        public CellPhone(string model)
        {
            this.Model = model;
        }

        //DC Current
        public void InputDirectCurrentCurrent()
        {
            Console.WriteLine("Cell phone charged with DC current");
        }
    }

    //Adapter class
    public class CellPhonePowerSupplyAdapter : HomePowerSupply
    {
        private CellPhone cellPhone = new CellPhone("Nokia");
        
        //AC current
        public override void InputAlternateCurrent()
        {
            cellPhone.InputDirectCurrentCurrent();
        }
    }


}
