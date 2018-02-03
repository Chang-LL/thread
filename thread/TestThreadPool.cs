using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MyThread.GenThreadPool;

namespace MyThread
{
    public class TestThreadPool
    {
        public int count;
        private object _lock = new object();

        public TestThreadPool(IThreadPool pool, int times)
        {
            count = 0;
            DateTime start = DateTime.Now;
            Console.WriteLine("Start Time for Job is "
                + DateTime.Now);
            for (int i = 0; i < times; i++)
            {
                Thread t1 = new Thread(
                    new ThreadStart(new Job(this).Run));
                pool.AddJob(t1);
            }
            Console.WriteLine("End Time for Job is " +
                DateTime.Now);
            Console.WriteLine("Performance using Pool[index]: ");
            Console.WriteLine(" " +
                (DateTime.Now - start).ToString());
            count = 0;
            start = DateTime.Now;

            Console.WriteLine("Start Time foe JobThread is " +
                DateTime.Now);
            for (int i = 0; i < times; i++)
            {
                Thread t = new Thread(new ThreadStart(new Job(this).Run));
                t.Start();
            }
            while (true)
            {
                lock (_lock)
                {
                    if (count == times)
                        break;
                }
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception)
                {
                }
            }
            Console.WriteLine("End Time For JobThread is " +
                DateTime.Now);
            Console.WriteLine("Performance using Pool[index]: ");
            Console.WriteLine(" " +
                (DateTime.Now - start).ToString());
        }

        sealed class JobThread
        {
            private object _lock = new object();
            private TestThreadPool tpf;
            public JobThread(TestThreadPool t)
            {
                tpf = t;
            }
            public void Run()
            {
                lock (_lock)
                {
                    tpf.count++;
                }
            }
        }
        sealed class Job
        {
            private object _lock = new object();
            private TestThreadPool tpf;
            public Job(TestThreadPool t)
            {
                tpf = t;
            }
            public void Run()
            {
                lock (_lock)
                {
                    tpf.count++;
                }
            }
        }
    }
    class TestPool
    {
        static void Main0()
        {
            IThreadPool tp = new GenThreadPoolImpl(200, 300, 300, true);
            TestThreadPool p = new TestThreadPool(tp, 100);
        }

    }
}
