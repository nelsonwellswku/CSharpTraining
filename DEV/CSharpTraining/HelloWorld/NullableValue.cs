using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class NullableValue<TValueType>
        where TValueType : struct, IComparable
    { 
        private bool _IsNull;

        public bool IsNull
        {
            get { return _IsNull; }
            private set 
            { _IsNull = value; }
        }

        private TValueType _Value;
        public TValueType Value 
        {
            get
            {
                return _Value;
            }
            set
            {
                IsNull = false;
                _Value = value;
            }
        }

        public NullableValue(TValueType number)
        {
            Value = number;
        }

        public NullableValue()
        {
             IsNull = true;
        }
    }
}
