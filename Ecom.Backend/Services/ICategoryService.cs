using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Services
{
	public interface ICategoryService
	{
		List<CategoryVm> GetListCategory();
		CategoryVm GetById(int id);
		Category Create(CategoryCreateVm newCategory);
		Category Update(CategoryVm categoryUp, int id);
		bool Delete(int id);
	}
}
