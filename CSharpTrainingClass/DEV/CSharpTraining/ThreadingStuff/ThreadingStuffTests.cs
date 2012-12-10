using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace ThreadingStuff
{
    [TestClass]
    public class ThreadingStuffTests
    {
        public ManualResetEventSlim ResetEvent { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            ResetEvent = new ManualResetEventSlim(false);
        }

        [TestMethod]
        public void VoidTaskExecute()
        {
            ManualResetEventSlim threadStarted =
                new ManualResetEventSlim(false);
            Task task = Task.Run(() =>
                {
                    threadStarted.Set();
                    ResetEvent.Wait();
                });
            threadStarted.Wait();
            Assert.AreEqual<TaskStatus>(TaskStatus.Running,
                task.Status);
            Assert.IsFalse(task.Wait(100));
            ResetEvent.Set();
            task.Wait();
        }
        [TestMethod]
        public void TaskExecute_Return42()
        {
            Task<int> task = Task<int>.Run(() =>
            {
                ResetEvent.Wait();
                return 42;
            });
            ResetEvent.Set();
            Assert.AreEqual<int>(42,
                task.Result);
        }

        [TestMethod]
        public void TaskExecute_ContinueWith_CheckResult()
        {
            ButtonClick();
        }

        public void ButtonClick()
        {
            int? result = null;
            Task task = Task<int>.Run(() =>
            {
                ResetEvent.Wait();
                return 42;
            }).ContinueWith((antecedent) =>
            {
                result = antecedent.Result;
            });
            ResetEvent.Set();

            task.Wait();
            Assert.AreEqual<int?>(42,
                result);
        }


        [TestMethod]
        public void TaskExecute_ThrowException()
        {
            Task task = Task.Run(() =>
            {
                ResetEvent.Wait();
                throw new InvalidOperationException();
            });
            ResetEvent.Set();
            try
            {
                task.Wait();
            }
            catch (AggregateException exception)
            {
                Assert.AreEqual<Type>(
                    typeof(InvalidOperationException),
                    exception.InnerException.GetType());
            }
            Assert.IsNotNull(task.Exception);
        }

        async public void AsyncInvocation()
        {
            Task task = new Task(() => 
                {
                    ResetEvent.Set();
                });
            await task;
            await task;
            ResetEvent.Wait();
        }

        [TestMethod]
        public void Parallel_WithoutSynchronization_ResultIsNot0()
        {
            decimal i = 0;
            Task task1 = Task.Run(() =>
                {
                    for (int count = 0; count < short.MaxValue; count++)
                    {
                        i++;
                    }
                });
            Task task2 = Task.Run(() =>
            {
                for (int count = 0; count < short.MaxValue; count++)
                {
                    i--;
                }
            });

            Task.WaitAll(task1, task2);
            Assert.AreNotEqual<decimal>(0,
                i);
                
        }
            
        object syncLock = new object();

        

        [TestMethod]
        public void Parallel_WithSynchronization_ResultIs0()
        {
            decimal i = 0;
            Task task1 = Task.Run(() =>
            {
                for (int count = 0; count < short.MaxValue; count++)
                {
                    lock (syncLock)
                    {
                        i++;
                    }
                }
            });
            Task task2 = Task.Run(() =>
            {
                for (int count = 0; count < short.MaxValue; count++)
                {
                    lock (syncLock)
                    {
                        i--;
                    }
                }
            });

            Task.WaitAll(task1, task2);
            Assert.AreEqual<decimal>(0,
                i);

        }


        [TestMethod]
        public void Parallel_WithInterlocked_ResultIs0()
        {
            int i = 0;
            Task task1 = Task.Run(() =>
            {
                for (int count = 0; count < short.MaxValue; count++)
                {
                    Interlocked.Increment(ref i);
                }
            });
            Task task2 = Task.Run(() =>
            {
                for (int count = 0; count < short.MaxValue; count++)
                {
                    Interlocked.Decrement(ref i);
                }
            });

            Task.WaitAll(task1, task2);
            Assert.AreEqual<decimal>(0,
                i);
        }

        [ThreadStatic]
        static int ThreadStaticNumber = 42;

        [TestMethod]
        public void ThreadStaticHasDifferentInstances()
        {
            int? threadStatic1 = null;
            //int? threadStatic2 = null;
            Task task = Task.Run(()=>
                threadStatic1 = ThreadStaticNumber);
            task.Wait();
            Assert.AreEqual<int?>(
                0, threadStatic1);
            ThreadStaticNumber = 73;
            Assert.AreNotEqual<int?>(
                ThreadStaticNumber, threadStatic1);
        }


        [TestMethod]
        public void ParallelSort_GivenIntegers_Sort()
        {

            int[] numbers = new int[] { 1, 2, 3 };

            numbers.AsParallel().Where(item => true);
            Parallel.ForEach(
                numbers, (item) => Console.WriteLine(item));
        }
    }
}
