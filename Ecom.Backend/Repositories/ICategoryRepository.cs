using Ecom.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public interface ICategoryRepository
	{
		List<Category> GetListCategory();
		Category GetById(int id);
		Category Create(Category newCategory);
		Category Update(Category category);
		bool Delete(Category category);

	}
}
