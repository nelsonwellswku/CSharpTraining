using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }

        public Employee(
            string firstName, string lastName, int employeeId)
            : base(firstName,lastName)
        {
            EmployeeId = employeeId;
        }

        override public string AsText()
        {
            return string.Format("{0} ({1})",
                base.AsText(), EmployeeId);
        }
    }
}
