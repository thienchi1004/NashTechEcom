using Ecom.Backend.Data;
using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;
		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;


		}
		public Product Create(Product newProduct)
		{
			if (newProduct.CategoryID == 0)
			{
				newProduct.CategoryID = null;
			}
			else
			{
				var category = _context.Categories.Find(newProduct.CategoryID);
				if (category == null)
				{
					return null;
				}
			}
			_context.Products.Add(newProduct);
			int result = _context.SaveChanges();
			if (result > 0)
			{ return newProduct; }
			else
			{ return null; }

	
		}

		public bool Delete(int id)
		{
			var product = _context.Products.Find(id);
			_context.Products.Remove(product);
			int result = _context.SaveChanges();
			if (result > 0)
			{ return true; }
			else
			{ return false; }

			 
		}

		public Product GetById(int id)
		{
			return _context.Products.AsNoTracking().Include(p => p.Category).FirstOrDefault(p => p.ProductID == id);
	
		}

		public List<Product> GetByCategory(int id)
		{
			return _context.Products.AsNoTracking().Where(p => p.CategoryID==id).ToList();
		}

		public List<Product> GetListProduct()
		{
			return _context.Products.AsNoTracking().ToList();
		}

		public Product Update(Product product)
		{
			if (product.CategoryID == 0)
			{
				product.CategoryID = null;
			}
			else
			{
				var category = _context.Categories.Find(product.CategoryID);
				if (category == null)
				{
					throw new Exception("Category " + product.CategoryID + " was not found");
				}
			}
			_context.Products.Update(product);
			int result = _context.SaveChanges();
			if (result > 0)
			{ return product; }
			else
			{ 
				throw new Exception("Can't update product with " + product.ProductID); 
			}
		}

		public List<Product> GetFeatureProducts(int number)
		{
			return _context.Products.AsNoTracking().OrderByDescending(p => p.RateStar).Take(number).ToList();
		}
	}
}
