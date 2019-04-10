using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class ChainOfResponsibilityPattern
    {
        public static void Test()
        {
            BankATM myATM = new BankATM();
            myATM.Withdraw(487);
        }
    }

    /*
     * There are three parts to the Chain of Responsibility pattern: sender, receiver, and request. 
     * A sender sends the request to the first receiver object in the chain. 
     * The sender only knows about this first object and nothing about the other receivers. 
     * The first receiver either handles the request and/or passes it on to the next one in the chain. 
     * Each receiver only knows about the next receiver in the line. 
     * The request will keep going down the line until the request was handled or there are no more receivers to pass it on to 
     * 
     * Example: When we withdraw the money from ATM, the ATM dispenses the different currency bills, it stats from $100, $50, $20, $10, $5, $1 
     */


    class MoneyStack
    {
        public int BillSize { get; set; }
        private MoneyStack Next { get; set; }

        public MoneyStack(int billsize)
        {
            BillSize = billsize;
        }

        public void Withdraw(int amount)
        {
            var numOfBills = amount / BillSize;

            if (numOfBills > 0)
            {
                EjectMoney(numOfBills);
                amount = amount - (numOfBills * this.BillSize);
            }

            if (amount > 0 && this.Next != null)
            {
                this.Next.Withdraw(amount);
            }
        }

        public void SetNextStack(MoneyStack nextMoneyStack)
        {
            this.Next = nextMoneyStack;
        }

        public void EjectMoney(int numOfBills)
        {
            Console.WriteLine(numOfBills + " $" + this.BillSize + " bill(s) has/have been dispensed.");
        }
    }

    class BankATM
    {
        MoneyStack stack100 = new MoneyStack(100);
        MoneyStack stack50 = new MoneyStack(50);
        MoneyStack stack20 = new MoneyStack(20);
        MoneyStack stack10 = new MoneyStack(10);
        MoneyStack stack5 = new MoneyStack(5);
        MoneyStack stack1 = new MoneyStack(1);

        MoneyStack currentStack;

        public BankATM()
        {
            stack100.SetNextStack(stack50);
            stack50.SetNextStack(stack20);
            stack20.SetNextStack(stack10);
            stack10.SetNextStack(stack5);
            stack5.SetNextStack(stack1);

            currentStack = stack100;
        }

        public void Withdraw(int amount)
        {
            currentStack.Withdraw(amount);
        }

    }
}
