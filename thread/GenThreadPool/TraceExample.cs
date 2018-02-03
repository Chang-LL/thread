using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread.GenThreadPool
{
    class TraceExample
    {
        static void Main0()
        {
            Trace.WriteLine("Entered Main()");
            for (int i = 0; i < 6; i++)
            {
                Trace.WriteLine(i);
            }
            Trace.WriteLine("Exiting from Main()");
        }
    }
}
