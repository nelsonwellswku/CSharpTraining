using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWorld
{
    public class MockTable<T>: ISerializable<T>, IEnumerable<T>
        where T : IEntity
    {
        
        private Dictionary<int, T> Storage { get; set; }

        public int Size { get { return Storage.Count; } }

        public MockTable()
        {
            Storage = new Dictionary<int, T>();
        }

        public void Add(params T[] entities)
        {
            foreach (T entity in entities)
            {
                Storage.Add(entity.EntityId, entity);
                EventHandler<OnAddEventArgs<T>> onAdd = OnAdd;
                if (onAdd != null)
                {
                    List<Exception> exceptions = new List<Exception>();
                    foreach (EventHandler<OnAddEventArgs<T>> item in
                        onAdd.GetInvocationList())
                    {
                        try
                        {
                            item(this, new OnAddEventArgs<T>(entity));
                        }
                        catch (Exception exception)
                        {
                            exceptions.Add(exception);
                        }
                    }
                    if (exceptions.Count > 0)
                    {
                        throw new AggregateException(
                            exceptions);
                    }
                }
            }
        }

        public T Get(int desiredEntityId)
        {
            return Storage[desiredEntityId];
        }

        //public IEnumerator GetEnumerator()
        //{
        //    return Storage.GetEnumerator();
        //}

        public bool Serialize(T data)
        {
            return true;
        }

        public bool Exists(int id)
        {
            return Storage.ContainsKey(id);
        }

        public int Count()
        {
            return Storage.Count;
        }

        public int Count(Predicate<T> func)
        {
            int count = 0;
            foreach (T item in Storage.Values)
            {
                if (func(item))
                {
                    count++;
                }
            }
            return count;
        }


        public IEnumerable<TReturn> Select<TReturn>(Func<T, TReturn> func)
        {
            List<TReturn> items = new List<TReturn>();
            foreach (T item in Storage.Values)
            {
                items.Add(func(item));
            }
            return items;
        }

        public event EventHandler<OnAddEventArgs<T>> OnAdd = delegate { };


        public IEnumerator<T> GetEnumerator()
        {
            IEnumerator<T> enumerator = Storage.Values.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
