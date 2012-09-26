using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    public class MockDatabase : IEnumerable<MockTable<IEntity>>
    {
        Initializer<Person> _PersonFactory = new Initializer<Person>(
            CreatePerson);
        public Person Person
        {
            get
            {
                return _PersonFactory.Value;
            }
        }

        static public Person CreatePerson()
        {
            return new Person("Inigo", "Montoya");
        }

        private readonly Dictionary<Type, MockTable<IEntity>> _Tables;
        private Dictionary<Type, MockTable<IEntity>> Tables
        {
            get { return _Tables; }
        }

        public MockDatabase()
        {
            _Tables = new Dictionary<Type,MockTable<IEntity>>();
        }

        public void Add<T>(T item)
            where T : IEntity
        {
            MockTable<IEntity> table = GetTypeTable(typeof(T));
            table.Add(item);
        }

        public bool Exists<T>(T item)
            where T : IEntity
        {
            MockTable<IEntity> table = GetTypeTable(typeof(T));
            return table.Exists(item.EntityId);
        }

        private MockTable<IEntity> GetTypeTable(Type type)
        {
            MockTable<IEntity> table;
            if (! Tables.TryGetValue(type,out table))
            {
                table = new MockTable<IEntity>();
                Tables[type] = table;
            }
            return table;
        }

        public bool TryGet<T>(int id, out T item)
        {
            item = (T)GetTypeTable(typeof(T)).Get(id);
            return !item.Equals(default(T));
        }

        public IEnumerator<MockTable<IEntity>> GetEnumerator()
        {
            foreach (var table in Tables)
            {
                yield return table.Value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
