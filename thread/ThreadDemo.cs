using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    class ThreadDemo
    {
        public void LongTask1()
        {
            for (int i = 0; i < 999; i++)
            {
                Console.WriteLine("Long Task 1 is  being executed");
            }
        }
        public void LongTask2()
        {
            for (int i = 0; i < 999; i++)
            {
                Console.WriteLine("Long Task 2 is  being executed");
            }
        }
        public static void Main0()
        {
            ThreadDemo t = new ThreadDemo();
            for (int i = 0; i < 50; i++)
            {
                Thread t1 = new Thread(new ThreadStart(t.LongTask1));
                t1.Start();
                Thread t2 = new Thread(new ThreadStart(t.LongTask2));
                t2.Start();
            }
            Console.Read();
        }
    }
}
