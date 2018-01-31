using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class TimerExample
    {
        private string message;
        private static Timer tmr;
        private static bool complete;
        public void GenerateText()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 01; i < 200; i++)
            {
                sb.Append( "This is Line ");
                sb.Append(i.ToString());
                sb.Append(System.Environment.NewLine);
            }
            message = sb.ToString();
        }
        public void GetText(object state)
        {
            if (message == null)
                return;
            Console.WriteLine("Messge is :\n" + message);
            tmr.Dispose();
            complete = true;
        }
        public static void Main0()
        {
            TimerExample obj = new TimerExample();
            Thread t = new Thread(new ThreadStart(obj.GenerateText));
            t.Start();
            TimerCallback timerCallback = new TimerCallback(obj.GetText);
            tmr = new Timer(timerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            do
            {
                if (complete)
                    break;
            } while (true);
            Console.WriteLine("Exiting Main...");
            Console.ReadLine();
        }
        
    }
}
