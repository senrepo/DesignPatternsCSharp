using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class PrototypePattern
    {

        public static void Test()
        {
            HumanCell humanCell = new HumanCell("human DNA");
            Cell humanCell1 = humanCell.Split();

            AnimalCell animalCell = new AnimalCell("animal DNA");
            Cell animalCell1 = animalCell.Split();

            if(humanCell.DNA == humanCell1.DNA) 
            {
                Console.WriteLine("Human cells cloned");
            }

            if(animalCell.DNA == animalCell1.DNA) 
            {
                Console.WriteLine("Human cells cloned");
            }

        }
    }

    //create new objects by copying/cloning the properties of existing object
    //cell split happens in humans, animals and plants to produce trillions of genetically identical cells during the healing process

    public abstract class Cell
    {
        public string DNA { get; set; }

        public Cell(string DNA)
        {
            this.DNA = DNA;
        }

        public abstract Cell Split();
    }


    public class HumanCell : Cell
    {
        public HumanCell(string DNA) : base (DNA)
        {
        }

        public override Cell Split()
        {
            return (Cell)this.MemberwiseClone();
        }
    }

    public class AnimalCell : Cell
    {
        public AnimalCell(string DNA) : base(DNA)
        {
        }

        public override Cell Split()
        {
            return (Cell)this.MemberwiseClone();
        }
    }

}
