using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class CompositePattern
    {
        public static void Test()
        {
            Composite root = new Composite(100);// Root
            Composite com1 = new Composite(200); //Composite 1
            Leaf leaf1 = new Leaf(10);//Leaf1
            Leaf leaf2 = new Leaf(20);//Leaf2
            //Add two leafs to composite1
            com1.AddChild(leaf1);
            com1.AddChild(leaf2);

            Leaf leaf3 = new Leaf(30);//Leaf3
            root.AddChild(com1);//Add composite1 to root
            root.AddChild(leaf3);//Add Leaf3 directlt to root

            root.Traverse();//Single method for both types.
        }
    }

    /* Composite Pattern: treat individual object and composition of object the same way.
     * Below example, leaf node can contain a value, but composite object can contain leaf node or another composite node.
     * In Binary Tree, the parent nodes treated as "composite node" and leaf node (node without any childeren) treated as "leaf node"
     */

    abstract class Component
    {
        abstract public void AddChild(Component c);
        abstract public void Traverse();
    }

    class Leaf : Component
    {
        private int value = 0;
        public Leaf(int val)
        {
            value = val;
        }
        public override void AddChild(Component c)
        {
            //no action; This method is not necessary for Leaf
        }
        public override void Traverse()
        {
            Console.WriteLine("Leaf:" + value);
        }
    }

    //A composite type.
    class Composite : Component
    {
        private int value = 0;
        private ArrayList ComponentList = new ArrayList();
        public Composite(int val)
        {
            value = val;
        }
        public override void AddChild(Component c)
        {
            ComponentList.Add(c);
        }
        public override void Traverse()
        {
            Console.WriteLine("Composite:" + value);
            foreach (Component c in ComponentList)
            {
                c.Traverse();
            }
        }
    }
}
