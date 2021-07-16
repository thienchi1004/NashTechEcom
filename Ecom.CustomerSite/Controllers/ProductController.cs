using Ecom.CustomerSite.Services.ProductClient;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductApiClient _productApi;
		public ProductController(IProductApiClient productApi)
		{
			_productApi = productApi;
		}
		public async Task<IActionResult> IndexAsync()
		{
			var products = await _productApi.GetListProduct();
			return View(products);
		}

		[Route("/category/{id}")]
		public async Task<IActionResult> Category(int id)
		{
			var cateroties = await _productApi.GetByCategory(id);
			return View(cateroties);
		}
		[Route("/detail")]
		public async Task<IActionResult> ProductDetailAsync(int id)
		{
			var product = await _productApi.GetById(id);
			return View(product);
		}
	}
}
