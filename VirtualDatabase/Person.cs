using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualDatabase
{
    public class Person : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age, int id = -1)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;

            if (id < 0)
            {
                Random rand = new Random();
                Id = rand.Next(0, 1000);
            }
            else
            {
                Id = id;
            }
        }
    }
}
