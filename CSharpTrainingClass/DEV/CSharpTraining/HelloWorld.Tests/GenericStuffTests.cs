using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace HelloWorld.Tests
{
    [TestClass]
    public class GenericStuffTests
    {
        [TestMethod]
        public void Generics()
        {
            Assert.AreEqual<Type>(
                typeof(Type), 
                Method<Type>(typeof(Type)));

            Assert.AreEqual<Type>(
                typeof(Type),
                Method(typeof(Type)));

            ValueType number = Method<int, ValueType>(1, 1);
            /// Type parameter cannot be inferred.
            /// int number = Method(1, 1);
    }

        public T Method<T>(T param1)
        {
            return param1;
        }

        public UReturn Method<T, UReturn>(int number, T param1) 
            where T: UReturn
        {
            return (UReturn)param1;
        }


        public TComparable AnotherMethod<TComparable>(TComparable item)
            where TComparable : IComparable<TComparable>
        {
            item.CompareTo(item);
            return item;
        }

        public IEnumerable Insert<TComparable>(
            IEnumerable items, TComparable item)
            where TComparable : IComparable<TComparable>
        {
            // figure out where in the list of items this item goes;
            item = AnotherMethod(item);
            return items;
        }
    }
}



