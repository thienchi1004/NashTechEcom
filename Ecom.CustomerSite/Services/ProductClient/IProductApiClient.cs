using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Services.ProductClient
{
	public interface IProductApiClient
	{
		Task<List<ProductVm>> GetListProduct();
		Task<ProductDetailVm> GetById(int id);
		Task<List<ProductVm>> GetByCategory(int id);
		Task<List<ProductVm>> GetFeatureProduct();
	}
}
