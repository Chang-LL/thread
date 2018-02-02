using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace MyThread
{
    class MethodImpl
    {
        //this attribute locks the method for use
        //by one and only one thread at a time
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DoSomeWorkSync()
        {
            Console.WriteLine("doSomeWorkSync()" +
                "--Lock held by Thread" +
                Thread.CurrentThread.GetHashCode());
            //when a thread sleeps,it still holds the lock
            Thread.Sleep(5 * 1000);
            Console.WriteLine("doSomeWorkSync()" +
                "--Lock released by Thread" +
                Thread.CurrentThread.GetHashCode());

        }
        //this is a non synchronized method
        public void DoSomeWorkNoSync()
        {
            Console.WriteLine("doSomeWorkNoSync()" +
                "--Entered Thread is " +
                Thread.CurrentThread.GetHashCode());
            Thread.Sleep(5 * 1000);
            Console.WriteLine("doSomeWorkNoSync()" +
                "--Leaving Thread is " +
                Thread.CurrentThread.GetHashCode());
        }

        [STAThread]
        static void Main0(string []args)
        {
            MethodImpl m = new MethodImpl();
            //Delegate for Non-Synchronous operaton
            ThreadStart tsNoSyncDelegate =
                new ThreadStart(m.DoSomeWorkNoSync);
            //Delegate for Synchronous operation
            ThreadStart tsSyncDelegate =
                new ThreadStart(m.DoSomeWorkSync);
            Thread t1 = new Thread(tsNoSyncDelegate);
            Thread t2 = new Thread(tsNoSyncDelegate);
            t1.Start();
            t2.Start();
            Thread t3 = new Thread(tsSyncDelegate);
            Thread t4 = new Thread(tsSyncDelegate);
            t3.Start();
            t4.Start();
        }
    }
}
