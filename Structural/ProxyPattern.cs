using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class ProxyPattern
    {
        public static void Test()
        {
            ATM atm = new ATM();
            atm.Deposit(100);
            atm.Withdraw(50);
            atm.CheckBalance();
        }
    }


    /* Proxy pattern: Provide a surrogate (take care of) for another class. Proxy can be used for below scenarios
     * virtual proxies -delaying the creation/initialization for expensive object until it needed (on-demand creation). 
     * protection proxies - access/denay the real object methods based on caller.
     * smart proxies - only one real object used with multiple instance of proxies.
     */

    public interface IFastBanking
    {
        void Deposit(int amount);
        void Withdraw(int amount);
        void CheckBalance();
    }

    public class Bank : IFastBanking
    {
        private int amount;

        #region IFastBanking Members

        public void Deposit(int depositAmount)
        {
            amount += depositAmount;
        }

        public void Withdraw(int withdrawAmount)
        {
            amount -= withdrawAmount;
        }

        public void CheckBalance()
        {
            Console.WriteLine("The current balance is " + amount);
        }

        #endregion

        public void UpdateProfile(string profile)
        {
            //update profile
        }
    }

    public class ATM : IFastBanking
    {
        private static Bank bank;

        #region IFastBanking Members

        public void Deposit(int amount)
        {
            //on demand loading of bank object
            if (bank == null)
            {
                bank = new Bank();
            }

            bank.Deposit(amount);
        }

        public void Withdraw(int amount)
        {
            if (bank == null)
            {
                bank = new Bank();
            }
            bank.Withdraw(amount);
        }

        public void CheckBalance()
        {
            if (bank == null)
            {
                bank = new Bank();
            }
            bank.CheckBalance();
        }

        #endregion

        //hiding the updateProfile method
    }



}
