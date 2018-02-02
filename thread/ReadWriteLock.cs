using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread
{
    public class ReadWriteLock
    {
        private ReaderWriterLock rwl;
        private int x, y;
        public ReadWriteLock()
        {
            rwl = new ReaderWriterLock();
        }
        public void Readlnts(ref int a, ref int b)
        {
            rwl.AcquireReaderLock(Timeout.Infinite);
            try
            {
                a = x;
                b = y;
            }
            finally
            {
                rwl.ReleaseReaderLock();
            }
        }
        public void Writelnts(int a,int b)
        {
            rwl.AcquireWriterLock(Timeout.Infinite);
            try
            {
                x = a;
                y = b;
                Console.WriteLine("x = " + x + " y = " +
                    y + " ThreadId = " +
                    Thread.CurrentThread.GetHashCode());
            }
            finally
            {
                rwl.ReleaseWriterLock();
            }
        }
    }
    public class RWApp
    {
        private ReadWriteLock rw = new ReadWriteLock();
        private void Write()
        {
            int a = 10;
            int b = 11;
            Console.WriteLine("****** Write ******");
            for (int i = 0; i < 5; i++)
            {
                rw.Writelnts(a++, b++);
                Thread.Sleep(1000);
            }
        }
        private void Read()
        {
            int a = 10;
            int b = 11;
            Console.WriteLine("****** Read ******");
            for (int i = 0; i < 5; i++)
            {
                rw.Readlnts(ref a, ref b);
                Console.WriteLine("For i=" + i + " a=" + a
                    + " b=" + b + " ThreadId = " +
                    Thread.CurrentThread.GetHashCode());
                Thread.Sleep(1000);
            }
        }
        public static void Main0()
        {
            RWApp e = new RWApp();
            Thread wt1 = new Thread(new ThreadStart(e.Write));
            wt1.Start();
            Thread wt2 = new Thread(new ThreadStart(e.Write));
            wt2.Start();
            Thread rt1 = new Thread(new ThreadStart(e.Read));
            rt1.Start();
            Thread rt2 = new Thread(new ThreadStart(e.Read));
            rt2.Start();
        }

    }
}
