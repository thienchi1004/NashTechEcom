using Ecom.Backend.Data;
using Ecom.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly ApplicationDbContext _context;
		public CategoryRepository(ApplicationDbContext context)
		{
			_context = context;


		}
		public Category Create(Category newCategory)
		{
			_context.Categories.Add(newCategory);
			int result = _context.SaveChanges();
			if (result >0)
			{
				return newCategory;
			}
			else
			{
				return null;
			}
		}

		public bool Delete(int id)
		{
			var category = _context.Categories.Find(id);
			_context.Categories.Remove(category);

			int result = _context.SaveChanges();

			if (result > 0)
			{ return true; }
			else
			{ return false; }
		}

		public Category GetById(int id)
		{
			return _context.Categories.Find(id);
		}

		public List<Category> GetListCategory()
		{
			return _context.Categories.ToList();
		}

		public Category Update(Category category)
		{
			_context.Categories.Update(category);
			int result = _context.SaveChanges();
			if (result > 0)
			{ return category; }
			else
			{ return null; }
		}
	}
}
