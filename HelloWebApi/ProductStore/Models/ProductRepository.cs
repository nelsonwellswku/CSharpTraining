using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductStore.Models
{
	public class ProductRepository : IProductRepository
	{
		private List<Product> _products = new List<Product>();
		private int _nextId = 1;

		public ProductRepository()
		{
			Add(new Product { Name = "Tomato Soup", Category = "Groceries", Price = 1.39M });
			Add(new Product { Name = "Yo-yo", Category = "Toys", Price = 3.75M });
			Add(new Product { Name = "Hammer", Category = "Hardware", Price = 16.99M });
		} 

		public IEnumerable<Product> GetAll()
		{
			return _products;
		}

		public Product Get(int id)
		{
			return _products.Find(p => p.Id == id);
		}

		public Product Add(Product item)
		{
			if (item == null)
			{
				throw new ArgumentException("item");
			}
			item.Id = _nextId++;
			_products.Add(item);
			return item;
		}

		public void Remove(int id)
		{
			_products.RemoveAll(p => p.Id == id);
		}

		public bool Update(Product item)
		{
			if (item == null)
			{
				throw new ArgumentException("item");
			}
			int index = _products.FindIndex(p => p.Id == item.Id);
			if (index == -1)
			{
				return false;
			}
			_products.RemoveAt(index);
			_products.Add(item);
			return true;
		}
	}
}