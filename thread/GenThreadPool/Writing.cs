using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread.GenThreadPool
{
    public class Writing
    {
        static BooleanSwitch bs;
        private static void WritingThread()
        {
            //Setting indent level
            Trace.IndentLevel = 2;
            //trace an info message
            Trace.WriteLine(DateTime.Now + " - Entered WritingThread()");
            //Sleeping for one sec...
            Thread.Sleep(1000);
            //trace an info message
            Trace.Indent();
            Trace.WriteLine(DateTime.Now + " - Slept for 1 second");
        }
        static void Main0()
        {
            //Create a Boolean switch called MySwitch
            bs = new BooleanSwitch("MySwitch",
                "Enable/Disable tracing functionalities");
            //Create a file listener
            FileStream fs = new FileStream(
               @"F:\D.log", FileMode.OpenOrCreate);
            Trace.Listeners.Add(new TextWriterTraceListener(fs));
            //write the line only when the switch is on
            Trace.WriteLineIf(bs.Enabled,DateTime.Now + " - Entered Main()");

            Thread t = new Thread(new ThreadStart(WritingThread));
            t.Start();
            Console.Read();
            Trace.Close();
        }
        static void Main00()
        {
            //Create a file listener
            FileStream fs = new FileStream(
                @"F:\D.log", FileMode.OpenOrCreate);
            Trace.Listeners.Add(new TextWriterTraceListener(fs));
            //write the
            Trace.WriteLine(DateTime.Now + " - Entered Main()");

            Thread t = new Thread(new ThreadStart(WritingThread));
            t.Start();
            Console.Read();
            Trace.Close();
        }
    }
}
