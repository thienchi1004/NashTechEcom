using Ecom.Backend.Models;
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
		bool Delete(Product product);
		List<Product> GetByCategory(int id);

	}
}
