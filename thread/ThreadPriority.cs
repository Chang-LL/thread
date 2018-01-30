using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyThread
{
    class ThreadPriority
    {
        public static Thread worker;
        public static void FindPriority()
        {
            Console.WriteLine("Name:" + worker.Name);
            Console.WriteLine("State:" + worker.ThreadState.ToString());
            Console.WriteLine("Priority:" + worker.Priority.ToString());
        }
        public static void Main0()
        {
            Console.WriteLine("Enter void Main");
            worker = new Thread(new ThreadStart(FindPriority))
            {
                //name the thread
                Name = "FindPriortyt()Thread"
            };
            worker.Start();
            Console.WriteLine("exiting void Main()");
        }
    }
}
