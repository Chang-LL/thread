using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    public class Lock
    {
        private int result = 0;
        public void CriticalSection()
        {
            lock (this)
            {
                Console.WriteLine("Entered Thread " +
                    Thread.CurrentThread.GetHashCode());
                for (int i = 0; i < 5; i++)
                {
                   
                    Console.WriteLine("WaitPulsel:Result = " +
                        result++ + " ThreadId " +
                        Thread.CurrentThread.GetHashCode());
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Exiting Thread " +
                    Thread.CurrentThread.GetHashCode());
            }
        }
        public static void Main0()
        {
            Lock e = new Lock();
            Thread t1 = new Thread(new ThreadStart(e.CriticalSection));
            t1.Start();
            Thread t2 = new Thread(new ThreadStart(e.CriticalSection));
            t2.Start();
        }
    }
}
