using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace HelloWorld
{
    static public class StandardCollectionOperators
    {
        static public IEnumerable<T> Where<T>(
            this MockTable<T> items, Predicate<T> func)
            where T:IEntity
        {
            if (func == null)
            {
                throw new ArgumentNullException(
                    "Predicate 'func' should not be null");
            }

            foreach (T item in items)
            {
                if (func(item))
                {
                    yield return item;
                }
            }
        }

    }
}
