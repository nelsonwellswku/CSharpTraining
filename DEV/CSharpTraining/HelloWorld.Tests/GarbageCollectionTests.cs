using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class GarbageCollectionTests
    {
        [TestCleanup]
        public void TestCleanup()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Assert.AreEqual<int>(
                0, Unicorn.PendingFinalizations);
        }

        [TestMethod]
        public void Finalization_IsNondeterministic()
        {
            Unicorn unicon = new Unicorn();

            Assert.AreEqual<int>(
                1, Unicorn.PendingFinalizations);

            unicon.Close();

            Assert.IsFalse(unicon.HasLotsOfData);
        }
        [TestMethod]
        public void Finalization_IDisposable()
        {
            Unicorn unicorn;
            using (unicorn = new Unicorn())
            {

                Assert.AreEqual<int>(
                    1, Unicorn.PendingFinalizations);

            }
            Assert.IsFalse(unicorn.HasLotsOfData);
        }
    }
}
