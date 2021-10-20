using System;

namespace LabWork1
{
    [AttributeUsage(AttributeTargets.Class,
        AllowMultiple = true)]
    public class ExportClass : Attribute
    {
        public int count { get; }

        public ExportClass()
        {
            count = 1;
        }

        public ExportClass(int count)
        {
            this.count = count;
        }
    }
}