using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HelloWorld;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class StringExTests
    {
        [TestMethod]
        public void Randomize_HelloWorld_Pass()
        {
            string original = "Hello, world!";
            Assert.AreEqual<string>("hello, world!", StringEx.Randomize(original));
            Assert.AreEqual<string>("hello, world!", original.Randomize());
            
            Assert.ReferenceEquals(original, "foo");
        }
    }


}
