using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public partial class Person : IEntity, IDebuggable
    {
        public int EntityId { get; set; }

        static void ValidateFirstName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "FirstName cannot be empty", "value"); 
            }
        }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}",
                    FirstName, LastName);
            }
        }

        virtual public string AsText()
        {
            return string.Format("{0}, {1}",
                LastName, FirstName);
        }

        string IDebuggable.Dump()
        {
            return AsText();
        }

        // Required by CA1033: 
        // Explicit interface methods should be callable by child types.
        protected void Dump()
        {
            ((IDebuggable)this).Dump();
        }
    }
}
