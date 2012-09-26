using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorld;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HelloWorld.Tests
{
    [TestClass]
    public class FactoryTests
    {
        [TestMethod]
        public void Create_Exception_Success()
        {
            Exception exception = Factory.Create<Exception>();
        }

        [TestMethod]
        public void Create_Person_Success()
        {
            Person person = Factory.Create(
                CreatePerson, "Inigo", "Montoya");

            Assert.AreEqual<string>("Inigo", person.FirstName);
        }

        public Person CreatePerson(string firstName, string secondName)
        {
            return new Person(firstName, secondName);
        }


        [TestMethod]
        public void Create_PersonUsingLambdaExpression_Success()
        {
            Person person = Factory.Create( 
                ()=> new Person("Inigo", "Montoya")
                );

            person = Factory.Create( () =>
            {
                string first = "Inigo";
                return new Person(first, "Montoya");
            });

            Assert.AreEqual<string>("Inigo", person.FirstName);
        }

        [TestMethod]
        public void Create_FuncStringStringInt_Success()
        {
            Func<string, string, int> func =
                (string text1, string text2) => (text1 + text2).Length;

            Assert.AreEqual<int>(0, func("",""));
        }

        [TestMethod]
        public void Create_FuncStringStringIntSimplified_Success()
        {
            Func<string, string, int> func =
                (text1, text2) => (text1 + text2).Length;
            Assert.AreEqual<int>(0, func("", ""));

            Func<string> func1 = () => "42"; 
            Func<object> castFunc = func1;

            Expression<Func<bool>> expression = () => true;
            Assert.IsTrue(expression.Compile().Invoke());

            Func<string, int> func2 =
                text1 => text1.Length;

            Assert.AreEqual<int>(0, func2(""));
        }
    }
}
