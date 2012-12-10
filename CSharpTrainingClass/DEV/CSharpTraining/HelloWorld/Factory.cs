using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    static public class Factory
    {
        static public T Create<T>()
            where T : new()
        {
            return new T();
        }

        static public T Create<T>(Func<T> method)
        {
            if (method == null) throw new ArgumentNullException("method");
            return method();
        }

        static public T Create<T, TFirst, TSecond>(
            Func<TFirst, TSecond, T> constructor, 
            TFirst first, TSecond second )
        {
            if (constructor == null)
            {
                throw new ArgumentNullException("constructor");
            }
            return constructor(first, second);
        }


        public static bool IsEqual<T>(T first, T second, Func<T, T, bool> comparer)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }
            return comparer(first, second);
        }
    }
}
