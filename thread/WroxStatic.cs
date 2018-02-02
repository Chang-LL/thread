using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    public class WroxStatic
    {
        [ThreadStatic]
        public static int x = 1;
        public static int y = 1;

        public void Run()
        {
            for (int i = 1; i <=10; i++)
            {
                Thread t2 = Thread.CurrentThread;
                x++;
                y++;
                Console.WriteLine("i= " + i +
                    " ThreadId= " + t2.GetHashCode() +
                    " x(static attribute)= " + x +
                    " y= " + y);
                Thread.Sleep(1000);
            }
        }
        public static void Main0()
        {
            WroxStatic ts = new WroxStatic();
            Thread t1 = new Thread(new ThreadStart(ts.Run));
            Thread t2 = new Thread(new ThreadStart(ts.Run));
            t1.Start();
            t2.Start();
        }
    }
}
