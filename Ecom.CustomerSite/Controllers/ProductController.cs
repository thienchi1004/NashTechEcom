using Ecom.CustomerSite.Services.CategoryClient;
using Ecom.CustomerSite.Services.ProductClient;
using Ecom.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
		private readonly ICategoryApiClient _categoryApi;

		public ProductController(IProductApiClient productApi, ICategoryApiClient categoryApi)
		{
			_productApi = productApi;
			_categoryApi = categoryApi;
		}

		[Route("/product")]
		public async Task<IActionResult> IndexAsync(int id = 0)
		{
			var products = await _productApi.GetListProduct();

			if (id > 0)
			{
				products = await _productApi.GetByCategory(id);
			}

			var categories = await _categoryApi.GetListCategory();
			ViewBag.Categories = categories;

			return View(products);
		}

		[Route("/detail")]
		public async Task<IActionResult> ProductDetailAsync(int id)
		{
			var product = await _productApi.GetById(id);
			return View(product);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> PostReview(int rate, string comments, int productId)
		{
			var rating = new RatingDetailVm
			{

				Comment = comments,
				Value = rate,
				ProductID = productId
			};

			await _productApi.PostReview(rating);

			return RedirectToAction("Detail", new { id = productId });
		}
	}
}
