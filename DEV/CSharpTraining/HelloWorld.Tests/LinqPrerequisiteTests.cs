using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class LinqPrerequisiteTests
    {
        [TestMethod]
        public void ImplicitLocalVariables()
        {
            var table1 = 
                new MockTable<Person>();

            MockTable<Person> table2 = 
                new MockTable<Person>();

            var table3 = GetPeople();

            string test = "forty-two";
            Assert.AreEqual<Type>(
                typeof(string), test.GetType());
        }

        [TestMethod]
        public void CreateAnonymousType()
        {
            var pair1 = new
            {
                First = "first",
                Second = "second"
            };

            var pair2 = new
                {
                First = "part 1",
                Second = "part 2"
                };

            Assert.AreEqual<string>(
                "first", pair1.First);
            Assert.AreEqual<string>(
                "second", pair1.Second);

            Employee employee = new Employee("Inigo", "Montoya", 42);
            var name = new
            {
                employee.FirstName,
                employee.LastName
            };
            Assert.AreEqual<string>(
                "Inigo", name.FirstName);
            Assert.AreEqual<string>(
                "Montoya", name.LastName);
            Assert.AreEqual<string>(
                "{ FirstName = Inigo, LastName = Montoya }", 
                name.ToString());

        }




        public MockTable<Person> GetPeople()
        {
            return new MockTable<Person>();
        }
    }
}
