using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class UnicornWhisperer : IDisposable
    {
        public Unicorn Unicorn { get; set; }

        public UnicornWhisperer()
        {
            Unicorn = new Unicorn();
        }

        ~UnicornWhisperer()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            Unicorn.Dispose();
            if (disposing)
            {
                // Release managed objects
            }
        }

        public void Dispose()
        {
            Dispose(false);
            GC.SuppressFinalize(this);
        }


    }
}
