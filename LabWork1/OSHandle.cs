using System;
using System.Runtime.InteropServices;

namespace LabWork1
{
    public class OSHandle : IDisposable
    {
        [DllImport("Kernel32.dll")]
        private static extern bool CloseHandle(IntPtr handle);

        private bool _idisposable;
        public IntPtr Handle { get; set; }

        public OSHandle()
        {
            Handle = IntPtr.Zero;
        }

        ~OSHandle()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (!_idisposable && Handle != IntPtr.Zero)
            {
                CloseHandle(Handle);
                Handle = IntPtr.Zero;
                _idisposable = true;
            }
            
        }
        
    }
}