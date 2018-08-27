using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace ConsoleApp256
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass unmanagedResource = new BaseClass();
            unmanagedResource.Dispose();
            Console.ReadLine();
        }
    }

    class BaseClass : IDisposable
    {
        //Flag:Has Dispose alreay been called?
        bool disposed = false;

        //Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        //Public implementation if Dispose pattern callable by consumers.
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if(disposed)
            {
                return;
            }

            if(disposing)
            {
                handle.Dispose();
                //Free any other managed objects here...
            }

            disposed = true;
        }
    }
}
