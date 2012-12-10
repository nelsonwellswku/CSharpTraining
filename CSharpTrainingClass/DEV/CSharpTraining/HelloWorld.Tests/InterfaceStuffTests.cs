using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HelloWorld;

namespace HelloWorld.Tests
{
    [TestClass]
    public class InterfaceStuffTests
    {
        [TestMethod]
        public void EntityId_Set_Success()
        {
            IEntity person = new Person("Inigo", "Montoya")
                { EntityId = 0xface };
            Assert.AreEqual<int>(person.EntityId, 0xface);
        }

        [TestMethod]
        public void Debuggable_Person_Success()
        {
            IDebuggable debuggable = new Person("Inigo", "Montoya")
                { EntityId = 0xface };
            string expected = ((Person)debuggable).AsText();
            Assert.AreEqual<string>(expected, debuggable.Dump());
        }
    }
}
