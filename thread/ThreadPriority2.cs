using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//线程出现故障；无法访问优先级
namespace MyThread
{
    class ThreadPriority2
    {
        public static Thread worker;
        public static Thread worker2;
        public static void FindPriority()
        {
            Console.WriteLine("Name:" + worker.Name);
            Console.WriteLine("State:" + worker.ThreadState.ToString());
            Console.WriteLine("Priority:" + worker.Priority.ToString());
        }
        public static void Main0()
        {
            Console.WriteLine("Enter void Main");
            worker = new Thread(new ThreadStart(FindPriority));
            worker2 = new Thread(new ThreadStart(FindPriority));
            //name the thread
            worker.Name = "FindPriortyt()Thread";
            worker2.Name = "FindPriortyt()Thread 2";                             
            //Give the new thread Object th hightest priority  
            worker2.Priority = System.Threading.ThreadPriority.Highest;
            worker.Start();
            worker2.Start();
            Console.WriteLine("exiting void Main()");
        }
    }
}
