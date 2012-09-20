using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualDatabase
{
    public class VDatabase<TEntity>
        where TEntity : class, IEntity
    {
        private TEntity[] collection;

        public VDatabase()
        {
            collection = new TEntity[100];            
        }

        public TEntity Retrieve(int id)
        {
            foreach (var item in collection)
            {
                if (item != null && item.Id == id)
                {
                    return item;
                }
            }

            return null;
        } 

        public void Delete(int id)
        {
            int itemCount = 0;

            foreach (var item in collection)
            {
                if (item != null && item.Id == id)
                {
                    collection.SetValue(null, itemCount);  
                }

                itemCount++;
            }
        }

        public int Insert(TEntity entity)
        {
            int itemCount = 0;

            foreach (var item in collection)
            {
                if (collection[itemCount] == null)
                {
                    collection.SetValue(entity, itemCount);
                    return entity.Id;
                }
            }

            return -1;
        }
    }
}
