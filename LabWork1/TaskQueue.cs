using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LabWork1
{
    public delegate void TaskDelegate();

    public class TaskQueue
    {
        private Thread[] poolOfThreads;
        private bool isDispose;
        private int countActiveThreads;


        private Queue<TaskDelegate> queueOfDelegates = new();

        public TaskQueue(int poolCount)
        {
            poolOfThreads = new Thread[poolCount];
            for (int i = 0; i < poolCount; i++)
            {
                poolOfThreads[i] = new Thread(ExecutionTasks)
                {
                    IsBackground = true
                };
                poolOfThreads[i].Start();
            }
        }

        public void EnqueueTask(TaskDelegate taskDelegate)
        {
            queueOfDelegates.Enqueue(taskDelegate);
        }

        private void ExecutionTasks()
        {
            TaskDelegate task;

            while (true)
            {
                if (queueOfDelegates.Count <= 0) continue;
                lock (queueOfDelegates)
                {
                    if (queueOfDelegates.Count <= 0) continue;
                    task = queueOfDelegates.Dequeue();
                }

                Interlocked.Increment(ref countActiveThreads);
                task?.Invoke();
                Interlocked.Decrement(ref countActiveThreads);
            }
        }

        public void Dispose()
        {
            while (queueOfDelegates.Count > 0 || countActiveThreads > 0)
            {
            }

            for (int i = 0; i < poolOfThreads.Length; i++)
            {
                poolOfThreads[i].Interrupt();
            }
        }
    }
}