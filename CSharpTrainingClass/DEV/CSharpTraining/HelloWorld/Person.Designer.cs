using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public partial class Person
    {
        #region FirstName
        private string _FirstName;
        public string FirstName 
        { 
            get 
            {
                return _FirstName;
            } 
            private set 
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                ValidateFirstName(value);
                _FirstName = value;
            } 
        }
        #endregion FirstName

        #region LastName
        private string _LastName;

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _LastName = value;
            }
        }
        #endregion LastName

        static partial void ValidateFirstName();

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }


    }
}
