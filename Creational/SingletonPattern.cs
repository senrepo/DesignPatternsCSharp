using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public class SingletonPattern
    {
        public static void Test()
        {
            SingletonBasic basic = SingletonBasic.Instance;

            SingletonStaticInitialization staticInitialization = SingletonStaticInitialization.Instance;

            SingletonMultithreaded multithreaded = SingletonMultithreaded.Instance;

        }
    }

    //Type 1: Basic version of Singleton
    //Advantages - lazy initialization, provide the option to perform initialization work in the get function
    //Disadvantages - not safe for multithreaded environment, allow to extend the class

    //http://msdn.microsoft.com/en-us/library/ff650316.aspx

    public class SingletonBasic
    {
        private static SingletonBasic instance;

        private SingletonBasic()
        {
        }

        public static SingletonBasic Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SingletonBasic();
                }

                return instance;
            }
        }
    }


    //Type2: Static Initialization of Singleton
    //Advantages - thead safty (readnly variables), derived class not allowed (sealed class)
    //Disadvantages - no lazy initialization, not provide the option to perform initialization work

    public sealed class SingletonStaticInitialization
    {
        //readonly variables can be assigned only during static initialization (which is shown here) or in a class constructor.
        private static readonly SingletonStaticInitialization instance = new SingletonStaticInitialization();

        private SingletonStaticInitialization()
        {
        }

        public static SingletonStaticInitialization Instance
        {
            get
            {
                return instance;
            }
        }
        
    }

    //Type3: Multithreaded Singleton
    //Advantages - thead safty (readnly variables), derived class not allowed (sealed class),
    //             lazy initialization, provide the option to perform initialization work
    //Disadvantages - none

    public sealed class SingletonMultithreaded
    {
        //volatile to ensure that assignment to variable completes before the variable can be accessed.
        private static volatile SingletonMultithreaded instance;
        private static object syncRoot = new object();

        private SingletonMultithreaded()
        {
        }

        public static SingletonMultithreaded Instance
        {
            get
            {
                if (instance == null)
                {

                    //lock (have double check by using lock) - solves the thread concurrency problems while avoiding an exclusive lock in every call to the Instance property method.
                    lock (syncRoot) //lock before entering critical regions
                    {
                        if (instance == null)
                            instance = new SingletonMultithreaded();
                    }
                }

                return instance;
            }
        }
    }

}
