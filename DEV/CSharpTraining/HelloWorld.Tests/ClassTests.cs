using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void CreatePerson()
        {
            
            Person person = new Person("Inigo", "Montoya");

            Assert.AreEqual<string>("Inigo", person.FirstName);
            Assert.AreEqual<string>("Montoya", person.LastName);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePerson_NullNames_ThrowsException()
        {

            Person person = new Person(null, null);



        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePerson_LastName_ThrowsException()
        {

            Person person = new Person("Inigo", "Montoya");
            person.LastName = null;


        }

        [TestMethod]
        public void AsText_InigoMontoya_Formatted()
        {
            Person person = new Person("Inigo", "Montoya");
            Assert.AreEqual<string>("Montoya, Inigo", person.AsText());
        }

        [TestMethod]
        public void UIntStuff()
        {
            
            //string move="ABABABAB";
            Assert.AreEqual<Type>(
                typeof(int), 1.GetType());
            Assert.AreEqual<Type>(
                typeof(uint), (true
                        ? 1
                        : 2U).GetType());
            //uint row =
            //    (move[0] == 'A')
            //        ? 0
            //        : (move[0] == 'B')
            //            ? 1U
            //            : 2;

        }
    }
}
