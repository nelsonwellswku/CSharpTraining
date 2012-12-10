using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using EntityDb;
using HelloWorld;
using System.Collections.Generic;
using HelloWorld.Tests;

namespace EntityDb.Tests
{
    [TestClass]
    public class MockTableTests
    {

        private MockTable<TestEntity> TestEntities { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            TestEntities = new MockTable<TestEntity>();
            TestEntities.Add(new TestEntity(42), new TestEntity(43), new TestEntity(44),
                new TestEntity(99), new TestEntity(0));
        }

        [TestMethod]
        public void Add_Success()
        {
            MockTable<TestEntity> database = new MockTable<TestEntity>();
            Assert.AreEqual<int>(0, database.Size);

            database.Add(new TestEntity(1234));
            Assert.AreEqual<int>(1, database.Size);

            database.Add(new TestEntity(5678));
            Assert.AreEqual<int>(2, database.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Add_Existing_Fails()
        {
            MockTable<TestEntity> database = new MockTable<TestEntity>();
            database.Add(new TestEntity(1234));
            database.Add(new TestEntity(1234));     // throws exception
        }

        [TestMethod]
        public void Find_Entity_Success()
        {
            MockTable<TestEntity> database = new MockTable<TestEntity>();
            database.Add(new TestEntity(1234));
            Assert.AreEqual<string>("1234", database.Get(1234).ToString());

            database.Add(new TestEntity(5678));
            Assert.AreEqual<string>("5678", database.Get(5678).ToString());
            Assert.AreEqual<string>("1234", database.Get(1234).ToString()); // Still
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Find_Nonexistent_ReturnsNull()
        {
            MockTable<TestEntity> database = new MockTable<TestEntity>();
            database.Add(new TestEntity(1234));
            Assert.IsNull(database.Get(5678));
        }

        [TestMethod]
        public void Exists_Success()
        {
            MockTable<TestEntity> database = new MockTable<TestEntity>();
            database.Add(new TestEntity(1234));
            Assert.IsTrue(database.Exists(1234));
        }

        [TestMethod]
        public void Exists_Failure()
        {
            MockTable<TestEntity> database = new MockTable<TestEntity>();
            database.Add(new TestEntity(1234));
            Assert.IsFalse(database.Exists(5678));
        }


        [TestMethod]
        public void Count_Given5Items_Return5()
        {
            Assert.AreEqual<int>(5, TestEntities.Count());
        }

        [TestMethod]
        public void Count_Given5Items_ReturnEven()
        {
            Assert.AreEqual<int>(3, TestEntities.Count( item => item.EntityId%2==0));
        }

        [TestMethod]
        public void Where_Given5Items_Return42()
        {
            IEnumerator<TestEntity> returns =  
                TestEntities.Where( item => item.EntityId==42 ).GetEnumerator();
            returns.MoveNext();
            Assert.AreEqual<int>(42, returns.Current.EntityId);
        }

        [TestMethod]
        public void Where_Given5Items_ReturnEven()
        {
            foreach (TestEntity item in TestEntities.Where(item => item.EntityId % 2 == 0))
            {
                Assert.IsTrue(item.EntityId % 2 == 0);
            }
        }

        [TestMethod]
        public void Select_TestEntity_To_Int()
        {
            TestEntities = new MockTable<TestEntity>();
            TestEntities.Add(new TestEntity(42), new TestEntity(43), new TestEntity(44),
                new TestEntity(99), new TestEntity(0) );

            IEnumerable<int> returns = TestEntities.Select(item => item.EntityId);
        }

        [TestMethod]
        public void ItemAdded_Event_Raised()
        {
            int invocationCount = 0;
            TestEntities.OnAdd += (sender, eventAargs) => invocationCount++;
            TestEntities.OnAdd += (sender, eventAargs) => invocationCount++;
            TestEntities.Add( new TestEntity(142) ); 
            Assert.AreEqual<int>(2, invocationCount);
        }

        [TestMethod]
        public void ItemAdded_RaiseException_PreventsNotification()
        {
            int invocationCount = 0;
            TestEntities.OnAdd +=
                (sender, eventAargs) =>
                {
                    throw new InvalidOperationException();
                };
            TestEntities.OnAdd += (sender, eventAargs) => invocationCount++;
            try
            {
                TestEntities.Add(new TestEntity(142));
            }
            catch (AggregateException)
            {
            }
            Assert.AreEqual<int>(1, invocationCount);
        }

        [TestMethod]
        public void Foreach_IterateOverItemsInTable()
        {
            MockTable<TestEntity> table = new MockTable<TestEntity>();
            int counter = 0;
            foreach (TestEntity entity in table)
            {
                counter++;
            }
            Assert.AreEqual<int>(0, counter);
        }

        [TestMethod]
        public void InitializeMockTable()
        {
            MockTable<TestEntity> table =
                new MockTable<TestEntity>()
                {
                    new TestEntity(42),
                    new TestEntity(140)
                };
            Assert.AreEqual<int>(2,
                table.Count());
        }

    }
}
