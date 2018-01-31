using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class ThreadSleep
    {
        public static Thread worker;
        public static Thread worker2;
        public static void Counter()
        {
            Console.WriteLine("Entering Counter");
            for (int i = 1; i < 50; i++)
            {
                Console.Write(i + " ");
                if (i == 10)
                    //Thread.Sleep(1000);
                    Thread.Sleep(System.TimeSpan.FromSeconds(1));
            }
            Console.WriteLine();
            Console.WriteLine("Exiting Counter");
        }
        public static void Counter2()
        {
            Console.WriteLine("Entering Counter2");
            for (int i = 51; i < 100; i++)
            {
                Console.Write(i + " ");
                if (i == 70)
                    Thread.Sleep(5000);
            }
            Console.WriteLine();
            Console.WriteLine("Exiting Counter2");
        }
        public static void Main0()
        {
            Console.WriteLine("Entering the void Main!");
            worker = new Thread(new ThreadStart(Counter));
            worker2 = new Thread(new ThreadStart(Counter2));
            //Make the worker2 object as highest priority
            worker2.Priority = System.Threading.ThreadPriority.Highest;
            worker.Start();
            worker2.Start();
            Console.WriteLine("Exiting the void Main!");
        }
    }
}
