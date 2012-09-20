using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirtualDatabase
{
    public class Animal : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int Age { get; set; }

        public Animal(string name, int age, int id = -1)
        {
            Name = name;
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
