using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class DisplayNameAttributeTests 
    {
        public TestContext TestContext { get; set; }
        
        [TestMethod]
        public void GetAttribute_OnDaysOfTheWeek_Success()
        {
            DaysOfTheWeek day = DaysOfTheWeek.Monday;
            Assert.AreEqual<string>("Monday", day.ToString());

            Assert.AreEqual<string>("MONDAY",
                DisplayNameAttribute.Format(day));
        }

        [TestMethod]
        public void MyTestMethod()
        {
            dynamic person = new JsonObject("filename");

            //Assert.AreEqual(
            //    "Inigo", person.GetValue("FirstName"));
            //Assert.AreEqual<string>(
            //    "Inigo", person.FirstName);

        }

        [TestMethod]
        public void GetAttribute_NoAttribute_Success()
        {
            DaysOfTheWeek day = DaysOfTheWeek.Tuesday;
            Assert.AreEqual<string>("Tuesday", day.ToString());

            Assert.AreEqual<string>("Tuesday",
                DisplayNameAttribute.Format(day));

        }
    }
}
