using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Services
{
	public interface IProductService
	{
		ProductDetailVm GetById(int id);

		List<ProductVm> GetListProduct();

		List<ProductVm> GetByCategory(int id);

		Product Create(ProductCreateVm newProduct);

		//Product Update(int id, ProductUpdateVm productUp);
		List<ProductVm> GetFeatureProducts(int number);
		bool Delete(int id);
	}
}
