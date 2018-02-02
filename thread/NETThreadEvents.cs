using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    public class NETThreadEvents
    {
        public static void Main0()
        {
            ManualResetEvent mansig = new ManualResetEvent(false);
            Console.WriteLine("ManualResetEvent Before WaitOne ");
            bool b = mansig.WaitOne(1000, false);
            Console.WriteLine("ManualResetEvent After WaitOne " + b);
        }
        public static void Main()
        {
            ManualResetEvent mansig = new ManualResetEvent(true);
            Console.WriteLine("ManualResetEvent Before WaitOne ");
            bool b = mansig.WaitOne(1000, false);
            Console.WriteLine("ManualResetEvent After WaitOne " + b);
        }
    }
}
