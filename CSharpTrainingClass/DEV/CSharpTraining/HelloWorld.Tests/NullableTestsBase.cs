using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public abstract class NullableTestsBase<TValueType>
        where TValueType : struct, IComparable
    {
        abstract public TValueType TestValue { get;  }
        
        [TestMethod]
        public void NullableValueTValueType_IsNull()
        {
            NullableValue<TValueType> number = 
                new NullableValue<TValueType>();

            Assert.IsTrue(number.IsNull);
        }
        [TestMethod]
        public void NullableValueInt_IsNotNull()
        {
            NullableValue<TValueType> number = 
                new NullableValue<TValueType>(TestValue);

            Assert.IsFalse(number.IsNull);
            Assert.AreEqual<TValueType>(TestValue, number.Value);
        }



    }
}
