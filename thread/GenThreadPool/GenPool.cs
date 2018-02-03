using System;

namespace MyThread.GenThreadPool
{
    public class GenPool
    {
        private GenThreadPoolImpl genThreadPoolImpl1;
        private GenThreadPoolImpl genThreadPoolImpl2;

        public GenPool(GenThreadPoolImpl genThreadPoolImpl1, GenThreadPoolImpl genThreadPoolImpl2)
        {
            this.genThreadPoolImpl1 = genThreadPoolImpl1;
            this.genThreadPoolImpl2 = genThreadPoolImpl2;
        }

        internal void Run()
        {
            throw new NotImplementedException();
        }
    }
}