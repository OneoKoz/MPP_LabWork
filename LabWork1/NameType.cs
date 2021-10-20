using System;
using System.Reflection;

namespace LabWork1
{
    public class NameType
    {
        public static void Load(string assemblyPath)
        {
            Assembly assembly;
            try
            {
                assembly = Assembly.LoadFile(assemblyPath);
            }
            catch
            {
                throw new ArgumentException("Unable to load : " + assemblyPath);
            }

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                if (type.IsPublic)
                {
                    Console.WriteLine(type.FullName);
                    if (type.IsDefined(typeof(ExportClass)))
                    {
                        ExportClass att = (ExportClass) type.GetCustomAttribute(typeof(ExportClass));
                        Console.WriteLine(att.count);
                    }
                }
            }
        }
    }
}