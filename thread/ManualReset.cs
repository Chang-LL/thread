using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    public class ManualReset
    {
        [STAThread]
        static void Main0()
        {
            ManualResetEvent manRe = new ManualResetEvent(true);
            bool state = manRe.WaitOne(1000, true);
            Console.WriteLine("ManualResetEvent After frist WaitOne " + state);
            //change state to non-signaled
            manRe.Reset();
            state = manRe.WaitOne(5000, true);
            Console.WriteLine("manualResetEvent After second Waitone " +
                state);
        }
        [STAThread]
        static void Main00()
        {
            ManualResetEvent manRe = new ManualResetEvent(false);
            bool state = manRe.WaitOne(5000, true);
            Console.WriteLine("ManualResetEvent After frist WaitOne " + state);
            //change state to non-signaled
            manRe.Set();
            state = manRe.WaitOne(5000, true);
            Console.WriteLine("manualResetEvent After second Waitone " +
                state);
        }
        [STAThread]
        static void Main000()
        {
            AutoResetEvent manRe = new AutoResetEvent(true);
            bool state = manRe.WaitOne(1000, true);
            Console.WriteLine("ManualResetEvent After frist WaitOne " + state);
            //change state to non-signaled
            state = manRe.WaitOne(5000, true);
            Console.WriteLine("manualResetEvent After second Waitone " +
                state);
            
        }
    }
}
