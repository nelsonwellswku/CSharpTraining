using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HelloWorld.Tests
{
    [TestClass]
    public class CoAndContraVariance
    {

        [TestMethod]
        public void Covariance()
        {

            IEnumerator<string> stringEnumerator =
                new List<string>() { "forty-two" }.GetEnumerator();

            // Converting from more specific to less specific will 
            // always be successful it if it only possible
            // to take the generic type (T) out of the type
            // you are casting to (IEnumerator<object>).
            // In this case, IEnumerator<object> only allows
            // returning (out) objects from an interface
            // that contains string.  Since casting string
            // to object always succeeeds the cast works.
            IEnumerator<object> objectEnumerator = stringEnumerator;  // No cast required.
            objectEnumerator.MoveNext();

            object text = objectEnumerator.Current;
            Assert.AreEqual<object>(
                "forty-two", text);

        }


        [TestMethod]
        public void Contravariance()
        {
            ISerializable<Person> serializablePerson = 
                new MockTable<Person>();

            // ISerializable<Employee> only allows you to pass parameters "in"
            // and therefore, casting from ISerializable<Person> to ISerializable<Employee
            // works because after the cast the result is more restrictive (only
            // allowing Employees to be inserted) - which would always work because
            // an employee is a Person and the original database was for Person objects.
            ISerializable<Employee> serializableEmployee = 
                serializablePerson;

        }
    }
}
