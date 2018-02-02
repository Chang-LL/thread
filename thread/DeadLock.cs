using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class DeadLock
    {
        int filed_1 = 0;
        private object lock_1 = new int[1];
        int field_2 = 0;
        private object lock_2 = new int[1];
        public void First(int val)
        {
            lock (lock_1)
            {
                Console.WriteLine("First:Acquired lock_1:" +
                    Thread.CurrentThread.GetHashCode() +
                    " Now Sleeping");

                //Try Commenting thread.sleep()
                Thread.Sleep(1000);
                Console.WriteLine("First:Acquired lock_1:" +
                   Thread.CurrentThread.GetHashCode() +
                   " Now wants lock_2");
                lock (lock_2)
                {
                    Console.WriteLine("First:Acquired lock_2:" +
                    Thread.CurrentThread.GetHashCode());
                    filed_1 = val;
                    field_2 = val;
                }
            }
        }
        public void Second(int val)
        {
            lock (lock_2)
            {
                Console.WriteLine("Second:Acquired lock_2:" +
                     Thread.CurrentThread.GetHashCode());
                lock (lock_1)
                {
                    Console.WriteLine("Second:Acquired lock_1:" +
                     Thread.CurrentThread.GetHashCode());
                    filed_1 = val;
                    field_2 = val;
                }
            }
        }
    }
    public class MainApp
    {
        DeadLock d = new DeadLock();
        public void Run1()
        {
            d.First(10);
        }
        public void Run2()
        {
            d.Second(10);
        }
        public static void Main0()
        {
            MainApp m = new MainApp();
            Thread t1 = new Thread(new ThreadStart(m.Run1));
            
            Thread t2 = new Thread(new ThreadStart(m.Run1));
            t1.Start();
            t2.Start();
        }
    }
        
}
