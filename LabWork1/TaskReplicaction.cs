using System;
using System.IO;
using System.Threading;

namespace LabWork1
{
    public class TaskReplication
    {
        private string lineFrom { get; }
        private string lineTo { get; }
        private int countOfFile;

        private TaskQueue _taskQueue;

        public TaskReplication(String lineFrom, String lineTo)
        {
            this.lineFrom = lineFrom;
            this.lineTo = lineTo;
            countOfFile = 0;
        }

        public int copyAll(int countOfThread)
        {
            if (Directory.Exists(lineFrom) && Directory.Exists(lineTo))
            {
                _taskQueue = new TaskQueue(countOfThread > 0 ? countOfThread : 3);
                checkFiles(lineFrom);
                _taskQueue.Dispose();
            }
            else
            {
                Console.WriteLine("it's not a directory");
                //todo throw 
            }

            return countOfFile;
        }

        private void checkFiles(string curDirectory)
        {
            var allFiles = Directory.GetFiles(curDirectory);
            if (!Directory.Exists(curDirectory.Replace(lineFrom, lineTo)))
            {
                Directory.CreateDirectory(curDirectory.Replace(lineFrom, lineTo));
            }

            if (allFiles.Length > 0)
            {
                foreach (var fileName in allFiles)
                {
                    _taskQueue.EnqueueTask(() =>
                    {
                        File.Copy(fileName, fileName.Replace(lineFrom, lineTo), true);
                        Interlocked.Increment(ref countOfFile);
                    });
                }
            }

            var allDirectories = Directory.GetDirectories(curDirectory);

            if (allDirectories.Length > 0)
            {
                foreach (String dir in allDirectories)
                {
                    Console.WriteLine(dir);
                    checkFiles(dir);
                }
            }
        }
    }
}