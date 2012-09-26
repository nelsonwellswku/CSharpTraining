using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelloWorld.Tests
{
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
    public class ExceptionStuffTests
    {
        [TestMethod]
        public void TryCatch_DivideByZeroException_CatchExceptions()
        {
            bool exceptionThrown = false;
            bool executed = false;
            try
            {
                int number = 0;
                number = 42 / number;
                executed = true;
            }
            catch (DivideByZeroException ) 
            {
                exceptionThrown = true;
            }
            Assert.IsTrue(exceptionThrown);
            Assert.IsFalse(executed);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CatchDivideByZeroException_ThrowNullReferenceException_ExceptionEscapes()
        {
            try
            {
                object thing = null;
                thing.ToString();
            }
            catch (DivideByZeroException)
            {
            }
        }

        [TestMethod]
        public void CatchSystemException_ThrowNullReferenceException_ExceptionCaught()
        {
            bool exceptionThrownAndCaught = false;
            try
            {
                object thing = null;
                thing.ToString();
            }
            catch (SystemException)
            {
                exceptionThrownAndCaught = true;
            }
            Assert.IsTrue(exceptionThrownAndCaught);
        }

        [TestMethod]
        public void CatchAllException_ThrowNullReferenceException_ExceptionCaught()
        {
            bool exceptionThrownAndCaught = false;
            try
            {
                throw new StackOverflowException();
            }
            catch (StackOverflowException)
            {
                exceptionThrownAndCaught = true;
            }            
           Assert.IsTrue(exceptionThrownAndCaught);
        }

        [TestMethod]
        public void Finally_ThrowNullReferenceException_FinallyExecutes()
        {
            int counter = 0;
            try
            {
                try
                {
                    throw new DivideByZeroException();
                }
                finally
                {
                    counter++;
                }
            }
            catch (DivideByZeroException)
            { 
                counter++;
            }
            finally
            {
                counter++;
            }

            Assert.AreEqual<int>(3, counter);
        }
    }
}
