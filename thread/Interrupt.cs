using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class Interrupt
    {
        public static Thread sleeper;
        public static Thread worker;
        public static void SleepThread()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write(i + " ");
                if(i==10||i==20||i==30)
                {
                    Console.WriteLine("Going to sleep at: " + i);
                    Thread.Sleep(20);
                }
            }
        }
        public static void AwakeTheThread()
        {
            for (int i = 51; i < 100; i++)
            {
                Console.Write(i + " ");
                if(sleeper.ThreadState==System.Threading.ThreadState.WaitSleepJoin)
                {
                    Console.WriteLine("Interrupting the sleeping thread");
                    sleeper.Interrupt();
                }
            }
        }
        public static void Main0()
        {
            Console.WriteLine("Entering the void Main!");
            sleeper = new Thread(new ThreadStart(SleepThread));
            worker = new Thread(new ThreadStart(AwakeTheThread));
            sleeper.Start();
            worker.Start();
            Console.WriteLine("Exiting the void Main!");
        }
    }
}
