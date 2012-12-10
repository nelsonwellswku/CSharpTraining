using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class OnAddEventArgs<T> : EventArgs
    {
        public OnAddEventArgs(T item)
        {
            Item = item;
        }
        public T Item { get; private set; }
    }
}
