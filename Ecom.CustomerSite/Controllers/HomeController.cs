using Ecom.CustomerSite.Models;
using Ecom.CustomerSite.Services.CategoryClient;
using Ecom.CustomerSite.Services.ProductClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IProductApiClient _productApi;
		private readonly ICategoryApiClient _categoryApi;

		public HomeController(ILogger<HomeController> logger, IProductApiClient productApi, ICategoryApiClient categoryApi )
		{
			_logger = logger;
			_productApi = productApi;
			_categoryApi = categoryApi;
		}

		public async  Task<ActionResult> Index()
		{
			var products = await _productApi.GetListProduct();

			var hotProducts = await _productApi.GetFeatureProduct();
			ViewBag.HotProducts = hotProducts;
			return View(products);
		}
		public IActionResult Contact()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
