using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread
{
    public class SimpleThread
    {
        public void SimpleMethod()
        {
            int i = 5;
            int x = 10;
            int result = i*x;
            Console.WriteLine("This code calculated the value"
                + result.ToString() + "from thread ID:"
                + AppDomain.GetCurrentThreadId().ToString());
        }
        public static void Main0()
        {
            //Calling the method from our current thread
            SimpleThread simpleThread = new SimpleThread();
            simpleThread.SimpleMethod();

            //Calling the method on a new thread
            ThreadStart ts = new ThreadStart(simpleThread.SimpleMethod);
            Thread t = new Thread(ts);
            t.Start();
            Console.ReadLine();
        }

    }
}
