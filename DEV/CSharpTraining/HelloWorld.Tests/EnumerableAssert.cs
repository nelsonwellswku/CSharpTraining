using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Tests
{
    static public class EnumerableAssert
    {
        /// <summary>
        /// Throws an AssertFailedException when the collections have different items regardless of order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expectedCollection"></param>
        /// <param name="actualCollection"></param>
        /// <remarks>If the item count is different and the items are different the items will be compared before the count</remarks>
        static public void AreEquivalent<T>(
            this IEnumerable<T> expectedCollection,
            IEnumerable<T> actualCollection)
        {
            AreEqual(expectedCollection.OrderBy(item => item),
                actualCollection.OrderBy(item => item));
        }

        /// <summary>
        /// Throws an AssertFailedException when the collections have different or in a different order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expectedCollection"></param>
        /// <param name="actualCollection"></param>
        /// <remarks>If the item count is different and the items are different the items will be compared before the count</remarks>
        static public void AreEqual<T>(
            this IEnumerable<T> expectedCollection,
            IEnumerable<T> actualCollection)
        {
            IEnumerator<T> e =
                expectedCollection.GetEnumerator();
            IEnumerator<T> a =
                actualCollection.GetEnumerator();

            int counter = 0;
            bool eMoveNext = false, aMoveNext = false;
            Func<IEnumerator<T>, IEnumerator<T>, bool> moveNextFunc = (eEnumerator, aEnumerator) =>
            {
                eMoveNext = e.MoveNext();
                aMoveNext = a.MoveNext();
                return eMoveNext && aMoveNext && eMoveNext == aMoveNext;
            };

            while (moveNextFunc(e, a))
            {
                Assert.AreEqual<T>(
                    e.Current, a.Current);
                counter++;
            }

            Assert.AreEqual<bool>(eMoveNext, aMoveNext,
                "There are a different number of items in each collection.");
        }
    }
}
