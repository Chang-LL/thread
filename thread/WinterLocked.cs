using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
//?
namespace MyThread
{
    class WinterLocked
    {
        public ManualResetEvent a = new ManualResetEvent(false);
        private int i = 5;
        public void Run(object s)
        {
            Interlocked.Increment(ref i);
            Console.WriteLine("{0} {1}",
                Thread.CurrentThread.GetHashCode(), i);
        }
        public static void Main0()
        {
            ManualResetEvent mR = new ManualResetEvent(false);
            WinterLocked wl = new WinterLocked();
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(wl.Run), 1);

            }
            mR.WaitOne(10000, true);
        }
    }
}
