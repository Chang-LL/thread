using System;
using System.Text;
using System.Threading;

namespace MyThread.GenThreadPool
{
    public interface IThreadPool
    {
        void AddJob(Thread jobToRun);
        Stats GetStats();
    }
}
