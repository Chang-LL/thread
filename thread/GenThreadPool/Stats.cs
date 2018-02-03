using System.Text;

namespace MyThread.GenThreadPool
{
    public struct Stats
    {
        public int maxThreads;
        public int minThreads;
        public int maxIdleTime;
        public int numThreads;
        public int pendingJobs;
        public int jobsInprogress;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("MaxThreads = ");
            sb.Append(maxThreads);
            sb.Append("\nMinThreads = ");
            sb.Append(minThreads);
            sb.Append("\nMaxIdleTime = ");
            sb.Append(maxIdleTime);
            sb.Append("\npending Jobs = ");
            sb.Append(pendingJobs);
            sb.Append("\nJobs In progress = ");
            sb.Append(jobsInprogress);

            return sb.ToString();

        }
    }
}