using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class NullableTests
    {
        [TestMethod]
        public void NullableValueInt_IsNull()
        {
            NullableValue<int> number = 
                new NullableValue<int>();

            Assert.IsTrue(number.IsNull);
        }
        [TestMethod]
        public void NullableValueInt_IsNotNull()
        {
            NullableValue<int> number = 
                new NullableValue<int>(42);

            Assert.IsFalse(number.IsNull);
            Assert.AreEqual<int>(42, number.Value);
        }



    }
}
