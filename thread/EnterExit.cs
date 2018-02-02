using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class EnterExit
    {
        private int result = 0;
        public EnterExit()
        {

        }
        public void NonCtricalSection()
        {
            Console.WriteLine("Entered Thread " +
                Thread.CurrentThread.GetHashCode());
            for(int i=1;i<=5;i++)
            {
                Console.WriteLine("Result = " + result++ + " ThreadID"
                    + Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
            Console.WriteLine("Exiting Thread " +
                Thread.CurrentThread.GetHashCode());
        }
        public void CtricalSection()
        {
            Monitor.Enter(this);
            Console.WriteLine("Entered Thread " +
                Thread.CurrentThread.GetHashCode());
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Result = " + result++ + " ThreadId"
                    + Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
            Console.WriteLine("Exiting Thread " +
                Thread.CurrentThread.GetHashCode());
            Monitor.Exit(this);
        }
        public static void Main0()
        {
            EnterExit e = new EnterExit();
            if (false)
            {
                Thread nt1 = new Thread
                    (new ThreadStart(e.NonCtricalSection));
                nt1.Start();
                Thread nt2 = new Thread
                    (new ThreadStart(e.NonCtricalSection));
                nt2.Start();
            }
            else
            {
                Thread nt1 = new Thread
                    (new ThreadStart(e.CtricalSection));
                nt1.Start();
                Thread nt2 = new Thread
                    (new ThreadStart(e.CtricalSection));
                nt2.Start();
            }
        }
    }
}
