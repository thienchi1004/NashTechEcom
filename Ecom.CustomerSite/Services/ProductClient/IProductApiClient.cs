using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Services.ProductClient
{
	interface IProductApiClient
	{
		Task<List<ProductVm>> GetListProduct();
		Task<ProductVm> GetById(int id);
		Task<List<ProductVm>> GetByCategory(int id);
	}
}
