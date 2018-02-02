using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    class WaitAndPulse
    {
        private int result = 0;
        private LockMe lM;
        public WaitAndPulse()
        {

        }
        public WaitAndPulse(LockMe l)
        {
            lM = l;
        }
        public void CriticalSection()
        {
            Monitor.Enter(lM);
            Console.WriteLine("WaitPulel:Entered Thread " +
                Thread.CurrentThread.GetHashCode());
            for (int i = 0; i < 5; i++)
            {
                Monitor.Wait(lM);
                Console.WriteLine("WaitPulsel:WokeUp");
                Console.WriteLine("WaitPulsel:Result = " +
                    result++ + " ThreadId " +
                    Thread.CurrentThread.GetHashCode());
                Monitor.Pulse(lM);
            }
            Console.WriteLine("WaitPulsel:Exiting Thread " +
                Thread.CurrentThread.GetHashCode());
            Monitor.Exit(lM);
        }
    }
    class WaitAndPulse2
    {
        private int result = 0;
        private LockMe lM;
        public WaitAndPulse2()
        {

        }
        public WaitAndPulse2(LockMe l)
        {
            lM = l;
        }
        public void CriticalSection()
        {
            Monitor.Enter(lM);
            Console.WriteLine("WaitPulel2:Entered Thread " +
                Thread.CurrentThread.GetHashCode());
            for (int i = 0; i < 5; i++)
            {
                Monitor.Pulse(lM);                
                Console.WriteLine("WaitPulsel2:Result = " +
                    result++ + " ThreadId " +
                    Thread.CurrentThread.GetHashCode());
                Monitor.Wait(lM);
                Console.WriteLine("WaitPulsel2:WokeUp");
            }
            Console.WriteLine("WaitPulsel2:Exiting Thread " +
                Thread.CurrentThread.GetHashCode());
            Monitor.Exit(lM);
        }
    }

    public class LockMe
    {
    }
    public class Program
    {
        public static void Main0()
        {
            LockMe l = new LockMe();
            WaitAndPulse e1 = new WaitAndPulse(l);
            WaitAndPulse2 e2 = new WaitAndPulse2(l);
            Thread t1 = new Thread(new ThreadStart(e1.CriticalSection));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(e2.CriticalSection));
            t2.Start();
            Console.ReadLine();
        }
    }
}
