using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HelloWorld;

namespace HelloWorld.Tests
{
    /// <summary>
    /// Summary description for DaysOfTheWeeksTests
    /// </summary>
    [TestClass]
    public class DaysOfTheWeeksTests
    {

        [TestMethod]
        public void DaysOfTheWeek_Print_Success()
        {
            Assert.AreEqual<string>(
                "Monday", DaysOfTheWeek.Monday.ToString());
            Assert.AreEqual<int>(1, (int)DaysOfTheWeek.Monday);
            Assert.AreEqual<DaysOfTheWeek>(DaysOfTheWeek.Monday,
                (DaysOfTheWeek)1);

        }

    
    }
}
