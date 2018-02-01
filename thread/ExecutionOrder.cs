using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class ExecutionOrder
    {
        static Thread t1;
        static Thread t2;
        public static void WriteFinished(string threadName)
        {
            switch (threadName)
            {
                case "T1":
                    Console.WriteLine();
                    Console.WriteLine("T1 Finished");
                    break;
                case "T2":
                    Console.WriteLine();
                    Console.WriteLine("T2 Finished");
                    break;
                default:
                    break;
            }
        }
        public static void Increment()
        {
            for (int i = 1; i <=1000000; i++)
            {
                if (i % 100000 == 0)
                    Console.Write("{" + Thread.CurrentThread.Name + "}");
            }
            WriteFinished(Thread.CurrentThread.Name);
        }
        public static void Main0()
        {
            t1 = new Thread(new ThreadStart(Increment));
            t2 = new Thread(new ThreadStart(Increment));
            t1.Name = "T1";
            t2.Name = "T2";
            t1.Start();
            t2.Start();
            Console.ReadLine();
        }
    }
}
