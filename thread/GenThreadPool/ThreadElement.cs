using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyThread.GenThreadPool
{
    public class ThreadElement
    {
        private bool idle;
        private Thread thread;
        public ThreadElement(Thread t)
        {
            thread = t;
            idle = true;
        }

        public bool Idle { get => idle; set => idle = value; }
        public Thread GetThread() => thread;
    }
}
