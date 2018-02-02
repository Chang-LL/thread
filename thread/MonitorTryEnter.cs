using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//exception

namespace MyThread
{
    public class MonitorTryEnter
    {
        public MonitorTryEnter()
        {

        }
        public void CriticalSection()
        {
            bool b=Monitor.TryEnter(this,1000);
            Console.WriteLine("Thread " +
                Thread.CurrentThread.GetHashCode()+
                " TryEnter Value "+b);
            for (int i = 1; i <= 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(i+" "+
                    Thread.CurrentThread.GetHashCode()+" ");            
            }
            Monitor.Exit(this);
        }
        public static void Main0()
        {
            MonitorTryEnter a = new MonitorTryEnter();
            Thread t1 = new Thread(new ThreadStart(a.CriticalSection));
            Thread t2 = new Thread(new ThreadStart(a.CriticalSection));
            t1.Start();
            t2.Start();
        }

    }
}
