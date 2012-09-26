using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HelloWorld.Tests
{

    [TestClass]
    public class NullableInt : NullableTestsBase<int>
    {
        public override int TestValue { get { return 42; } }
    }
}
