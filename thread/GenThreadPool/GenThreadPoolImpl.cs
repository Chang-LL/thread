using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyThread.GenThreadPool
{
    public class GenThreadPoolImpl : IThreadPool
    {
        private int maxThreads;
        private int minThreads;
        private int maxIdleTime;
        private static bool debug;
        private ArrayList pendingJobs;
        private ArrayList availableThreads;

        public bool Debug { get => debug; set => debug = value; }
        public ArrayList PendingJobs { get => pendingJobs; set => pendingJobs = value; }
        public ArrayList AvailableThreads { get => availableThreads; }
        public int MaxIdleTime { get => maxIdleTime; set => maxIdleTime = value; }
        public int MinThreads { get => minThreads; set => minThreads = value; }
        public int MaxThreads { get => maxThreads; set => maxThreads = value; }

        public GenThreadPoolImpl()
        {
            maxThreads = 1;
            minThreads = 0;
            maxIdleTime = 300;
            pendingJobs = ArrayList.Synchronized(new ArrayList());
            availableThreads = ArrayList.Synchronized(new ArrayList());
            debug = false;
        }
        public GenThreadPoolImpl(int _maxThreads, int _minThreads, int _maxIdleTime)
        {
            maxThreads = _maxThreads;
            minThreads = _minThreads;
            maxIdleTime = _maxIdleTime;
            pendingJobs = ArrayList.Synchronized(new ArrayList());
            availableThreads = ArrayList.Synchronized(new ArrayList());
            debug = false;
            InitAvailableThreads();
        }
        public GenThreadPoolImpl(int _maxThreads, int _minThreads,
            int _maxIdleTime, bool _debug)
        {
            maxThreads = _maxThreads;
            minThreads = _minThreads;
            maxIdleTime = _maxIdleTime;
            pendingJobs = ArrayList.Synchronized(new ArrayList());
            availableThreads = ArrayList.Synchronized(new ArrayList());
            debug = _debug;
            InitAvailableThreads();
        }
        private void InitAvailableThreads()
        {
            if (minThreads > 0)
                for (int i = 0; i < minThreads; i++)
                {
                    Thread t = new Thread(
                        new ThreadStart(new GenPool(this, this).Run));
                    ThreadElement e = new ThreadElement(t);
                    e.Idle = true;
                    availableThreads.Add(e);
                }
            Console.WriteLine("Initialized the ThreadPool. "
                + " Number of Available threads: "
                + availableThreads.Count);
        }

        public void AddJob(Thread job)
        {
            if (job == null) return;
            lock (this)
            {
                pendingJobs.Add(job);
                int index = findFirstIdleThread();
                if (debug)
                    Console.WriteLine("First Idle Thread is " + index);
                if (index == -1)
                {
                    if (maxThreads == -1
                        || availableThreads.Count < maxThreads)
                    {
                        if (debug)
                        {
                            Console.WriteLine("Creating a new thread");
                            Thread t = new Thread(new ThreadStart(new GenPool(this, this).Run));
                            ThreadElement e = new ThreadElement(t);
                            e.Idle = false;
                            e.GetThread().Start();
                            try
                            {
                                availableThreads.Add(e);
                            }
                            catch (OutOfMemoryException)
                            {

                                Console.WriteLine("Out of Memory");
                                availableThreads.Add(e);
                                Console.WriteLine("Added job again");
                            }
                            return;
                        }


                    }
                }
            }

            public Stats GetStats()
            {
                throw new NotImplementedException();
            }
        }
    }
