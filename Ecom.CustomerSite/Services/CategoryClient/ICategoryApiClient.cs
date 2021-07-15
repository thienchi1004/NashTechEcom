using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Services.CategoryClient
{
	public interface ICategoryApiClient
	{
		Task<List<CategoryVm>> GetListCategory();
	}
}
