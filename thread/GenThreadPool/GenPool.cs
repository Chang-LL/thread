using System;
using System.Threading;

namespace MyThread.GenThreadPool
{
    public class GenPool
    {
        private GenThreadPoolImpl gn;
        private object _lock;

        public GenPool(object lock_, GenThreadPoolImpl gn_)
        {
            gn = gn_;
            _lock = lock_;
        }

        public void Run()
        {
            Thread job = null;
            try
            {
                while (true)
                {
                    while (true)
                    {
                        lock (_lock)
                        {
                            if(gn.PendingJobs.Count==0)
                            {
                                int index = gn.FindThread();
                                if (index == -1) return;
                                ((ThreadElement)gn.AvailableThreads[index]).Idle = true;
                                break;
                            }
                            job = (Thread)gn.PendingJobs[0];
                            gn.PendingJobs.RemoveAt(0);
                        }
                        job.Start();
                    }
                    try
                    {
                        lock (this)
                        {
                            if (gn.MaxIdleTime == -1)
                                Monitor.Wait(this);
                            else Monitor.Wait(this, gn.MaxIdleTime);
                        }
                    }
                    catch (Exception)
                    {  
                        
                    }
                    lock(_lock)
                    {
                        if(gn.PendingJobs.Count==0)
                        {
                            if(gn.MinThreads!=-1&&
                                gn.AvailableThreads.Count>gn.MinThreads)
                            {
                                gn.RemoveThread();
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}