using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//Exception
//不应该有的异常
namespace MyThread
{
    public class WroxMutex
    {
        static Mutex mutex;
        public void Run()
        {
            Console.WriteLine("In Run");
            mutex.WaitOne();
            Console.WriteLine("Thread sleeping for 10 secs");
            Thread.Sleep(10000);
            Console.WriteLine("End of Run() method");
        }
        public static void Main0()
        {
            mutex = new Mutex(true, "WROX");
            WroxMutex nm = new WroxMutex();
            Thread t = new Thread(new ThreadStart(nm.Run));
            t.Start();
            Console.WriteLine("Thread Sleep for 5 sec");
            Thread.Sleep(5000);
            Console.WriteLine("Thread Woke Up");
            mutex.ReleaseMutex();
            Console.WriteLine("Before WaitOne");
            mutex.WaitOne();
            Console.WriteLine("Lock owned by Main Thread");
        }
    }
}
