using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HelloWorld;

namespace HelloWorld.Tests
{
    [TestClass]
    public class MockDatabaseTests
    {
        [TestMethod]
        public void CreateMockDatabase_Success()
        {
            MockDatabase database = new MockDatabase();
        }

        [TestMethod]
        public void Add_Person_Success()
        {
            MockDatabase database = new MockDatabase();
            Person person = new Person("Inigo", "Montoya")
                { EntityId = 42 };
            database.Add<Person>(person);
            Assert.IsTrue(database.Exists<Person>(person));
        }

        [TestMethod]
        public void Add_Employee_Success()
        {
            MockDatabase database = new MockDatabase();
            Employee employee = new Employee("Inigo", "Montoya", 1234)
                { EntityId = 42 };
            database.Add<Employee>(employee);
            Assert.IsTrue(database.Exists<Employee>(employee));
        }

        [TestMethod]
        public void Exists_Person_Failure()
        {
            MockDatabase database = new MockDatabase();
            Person person = new Person("Inigo", "Montoya")
                { EntityId = 42 };
            Assert.IsFalse(database.Exists<Person>(person));
        }

        [TestMethod]
        public void Exists_Employee_Failure()
        {
            MockDatabase database = new MockDatabase();
            Employee employee = new Employee("Inigo", "Montoya", 1234)
                { EntityId = 42 };
            Assert.IsFalse(database.Exists<Employee>(employee));
        }

        [TestMethod]
        public void Get_Person_Success()
        {
            MockDatabase database = new MockDatabase();
            Employee employee = new Employee("Inigo", "Montoya", 1234) 
                {EntityId = 42};
            database.Add(employee);
            Assert.IsTrue(database.TryGet(42, out employee));
            Assert.AreEqual<int>(1234, employee.EmployeeId);
        }

        [TestMethod]
        public void InitizlizerPerson_Success()
        {
            MockDatabase database = new MockDatabase();
            Person person = database.Person;
            Assert.IsNotNull(person);
            Assert.AreEqual<Person>(person, database.Person);
        }

        [TestMethod]
        public void Index_SelectTestEntity_ReturnTestEntityMockTable()
        {
            MockDatabase database = new MockDatabase();
            database.Add(new TestEntity(42));
            MockTable <IEntity> testEntities =
                database[typeof(TestEntity)];
        }
    }
}
