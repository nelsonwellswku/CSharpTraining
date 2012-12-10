using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using VirtualDatabase;

namespace VirtualDatabase.tests
{
    [TestClass]
    public class VirtualDatabaseTests
    {
        [TestMethod]
        public void Delete_Success()
        {
            VDatabase<IEntity> virtualDatabase = new VDatabase<IEntity>();
            IEntity person = new Person("Nelson", "Wells", 26, 101);

            int id = virtualDatabase.Insert(person);
            virtualDatabase.Delete(101);

            Assert.IsNull(virtualDatabase.Retrieve(id));
        }

        [TestMethod]
        public void InsertAndRetrieve_InsertAnimalSocksThenRetrieve_Success()
        {
            VDatabase<IEntity> virtualDatabase = new VDatabase<IEntity>();
            IEntity animal = new Animal("Socks", 7, 100);

            int id = virtualDatabase.Insert(animal);
            
            Assert.AreEqual<int>(id, 100);

            Animal actual = (Animal)(virtualDatabase.Retrieve(100));
            Assert.AreEqual<string>("Socks", actual.Name);

        }
    }
}
