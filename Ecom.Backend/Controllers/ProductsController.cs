using Ecom.Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Shared.ViewModels;
using Ecom.Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Ecom.Backend.Services;

namespace Ecom.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductsController(IProductRepository productRepo, IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public ActionResult<List<ProductVm>> GetListProduct(int categoryId = 0)
		{
			List<ProductVm> listProduct;
			if (categoryId > 0)
			{
				listProduct = _productService.GetByCategory(categoryId);
			}
			else
			{
				listProduct = _productService.GetListProduct();
			}
			
			return Ok(listProduct);
		}

		[HttpGet("feature/{number}")]
		public ActionResult<List<ProductVm>> GetFeatureProducts(int number)
		{
			List<ProductVm> listProduct;
			if (number <= 0)
			{
				return BadRequest();
			}


			listProduct = _productService.GetFeatureProducts(number);

			return Ok(listProduct);
		}


		[HttpGet("{id}")]
		public ActionResult<ProductDetailVm> GetById(int id)
		{
			var product = _productService.GetById(id);

			if (product == null)
			{
				return NotFound();
			}

			return Ok(product);
		}


		[HttpPost]
		public ActionResult<Product> Create(ProductCreateVm newProduct)
		{
			var result = _productService.Create(newProduct);
			
			if(result == null)
			{
				return BadRequest();
			}

			return result;
		}


		//[HttpPut("{id}")]
		//public ActionResult<ProductDetailVm> Update(ProductUpdateVm productUp, int id)
		//{
		//	var productExist = _productService.GetById(id);
		//	if (productExist == null)
		//	{
		//		return NotFound();
		//	}
			
		//	var result = _productService.Update(id,productUp);
		//	if (result != null)
		//	{
		//		return NoContent();
		//	}
		//	else
		//	{
		//		return Problem("Can't create product");
		//	}
		//}


		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var result = _productService.Delete(id);
			if (result == true)
			{
				return Ok();
			}
			else
			{
				return Problem("Can't delete product");
			}
		}

		

	}
}
