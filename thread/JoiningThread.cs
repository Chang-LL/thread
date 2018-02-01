using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    class JoiningThread
    {
        public static Thread secondThread;
        public static Thread firstThread;
        static void First()
        {
            for (int i = 0; i < 2500; i++)
            {
                Console.Write(i + " ");
            }
        }
        static void Second()
        {
            firstThread.Join();
            for (int i = 2500; i < 5000; i++)
            {
                Console.Write(i + " ");
            }
        }
        public static void Main0()
        {
            firstThread = new Thread(new ThreadStart(First));
            secondThread = new Thread(new ThreadStart(Second));
            firstThread.Start();
            secondThread.Start();
        }
    }
}
