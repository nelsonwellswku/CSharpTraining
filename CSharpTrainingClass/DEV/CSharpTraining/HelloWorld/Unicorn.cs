using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class Unicorn : IDisposable
    {
        public bool HasLotsOfData { get; set; }
        public static int PendingFinalizations { get; set; }

        public Unicorn()
        {
            HasLotsOfData = true;
            PendingFinalizations++;
        }

        ~Unicorn()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            HasLotsOfData = false;
            PendingFinalizations--;
            if (disposing)
            {
                // Release managed objects
            }
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
