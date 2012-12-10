using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.Tests
{
    class TestEntity : IEntity
    {
        private readonly int _Value;
        public int EntityId { get { return _Value; } }

        public TestEntity(int value)
        {
            _Value = value;
        }

        public override string ToString()
        {
            return _Value.ToString();
        }
    }
}
