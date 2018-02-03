using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class RegWait
    {
        private static int i = 0;
        public static void Main()
        {
            AutoResetEvent autoReset = new AutoResetEvent(false);
            ThreadPool.RegisterWaitForSingleObject(
                autoReset, new WaitOrTimerCallback(Workitem), null, 2000, false);
            autoReset.Set();
            Console.Read();
        }
        public static void Workitem(object o,bool signaled)
        {
            i += 1;
            Console.WriteLine("Thread Pool Work Item Invoked: " + i.ToString());
        }
    }
}
