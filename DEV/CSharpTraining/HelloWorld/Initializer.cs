using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class Initializer<T>
    {
        public bool IsAssigned { get; private set; }

        private T _Value;
        public T Value
        {
            get
            {
                if (!IsAssigned)
                {
                    Value = Create();
                }
                return _Value;
            }
            set
            {
                _Value = value;
                IsAssigned = true;
            }
        }

        private Func<T> Create { get; set; }

        public Initializer(Func<T> constructor)
        {
            Create = constructor;
            IsAssigned = false;
        }
    }
}
