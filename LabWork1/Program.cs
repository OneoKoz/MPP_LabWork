using System;
using System.IO;

namespace LabWork1
{
    static class Program
    {
        static void Main(string[] args)
        {
            TaskReplication taskReplication = new TaskReplication(args[0], args[1]);
            Console.WriteLine(taskReplication.copyAll(10 ));
            // TaskQueue taskQueue = new TaskQueue(2);
            // TaskDelegate taskDelegate = Sum;
            // taskQueue.EnqueueTask(taskDelegate);
            // taskDelegate = Cut;
            // taskQueue.EnqueueTask(taskDelegate);
            // taskDelegate = Enter;
            // taskQueue.EnqueueTask(taskDelegate);
            // taskQueue.Dispose();
            // Console.WriteLine("h");
        }

        private static void Sum()
        {
            Console.WriteLine("SumSum");
        }

        private static void Cut()
        {
            Console.WriteLine("CUTCUT");
        }

        private static void Enter()
        {
            Console.WriteLine("EnterEnter");
        }
    }
}