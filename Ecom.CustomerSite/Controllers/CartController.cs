using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Cart()
		{
			return View();
		}
		public IActionResult CheckOut()
		{
			return View();
		}
	}
}
