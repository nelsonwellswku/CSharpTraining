using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class NullableValue<TValueType>
    {
        private bool _IsNull;
        public bool IsNull
        {
            get
            {
                return _IsNull;
            }
            private set
            {
                _IsNull = value;
            }
        }

        public TValueType Value { get; set; }
        
        public NullableValue(TValueType number)
        {
            Value = number;
        }

        public NullableValue(object obj)
        {
            if (obj == null)
            {
                IsNull = true;
            }
            else
            {
                Value = (TValueType)obj;
            }
        }
    }
}
