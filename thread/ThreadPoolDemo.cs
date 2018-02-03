using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    class ThreadPoolDemo
    {
        public void LongTask1(object obj)
        {
            for (int i = 0; i < 999; i++)
            {
                Console.WriteLine("Long Task 1 is  being executed");
            }
        }
        public void LongTask2(object obj)
        {
            for (int i = 0; i < 999; i++)
            {
                Console.WriteLine("Long Task 2 is  being executed");
            }
        }
        public static void Main0()
        {
            ThreadPoolDemo t = new ThreadPoolDemo();
            for (int i = 0; i < 50; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(t.LongTask1));
                ThreadPool.QueueUserWorkItem(new WaitCallback(t.LongTask2));

            }
            Console.Read();
        }
    }
}
