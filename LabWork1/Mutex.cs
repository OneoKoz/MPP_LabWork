using System.Threading;

namespace LabWork1
{
    public class Mutex
    {
        private int threadID;

        public Mutex()
        {
            threadID = 0;
        }

        public void Lock()
        {
            int curThreadId = Thread.CurrentThread.ManagedThreadId;
            while (Interlocked.CompareExchange(ref threadID, curThreadId, 0) != 0)
            {
                Thread.Sleep(20);
                //do smth
            }
        }

        public void Unlock()
        {
            int curThreadId = Thread.CurrentThread.ManagedThreadId;
            Interlocked.CompareExchange(ref threadID, 0, curThreadId);
        }
    }
}