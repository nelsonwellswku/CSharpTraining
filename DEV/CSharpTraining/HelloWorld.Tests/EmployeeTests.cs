using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class EmployeeTests
    {

        public Employee Employee { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Employee = new Employee("Inigo", "Montoya", 1234);
        }

        [TestMethod]
        public void CreateEmployee()
        {
            Employee employee = new Employee("Inigo", "Montoya", 1234);
            Assert.AreEqual<int>(employee.EmployeeId, 1234);
        }

        [TestMethod]
        public void OverrideAsText_InigoMontoya_Formatted()
        {
            Assert.AreEqual<string>("Montoya, Inigo (1234)", Employee.AsText());
            Assert.AreEqual<string>("Montoya, Inigo (1234)", ((Person)Employee).AsText());
        }
    }
}
