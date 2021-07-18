using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public interface IProductRepository
	{
		List<Product> GetListProduct();
		Product GetById(int id);
		Product Create(Product newProduct);
		Product Update(Product product);
		bool Delete(int id);
		List<Product> GetByCategory(int id);
		List<Product> GetFeatureProducts(int number);

	}
}
