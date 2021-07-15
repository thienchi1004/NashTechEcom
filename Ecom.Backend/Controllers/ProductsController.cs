using Ecom.Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecom.Shared.ViewModels;
using Ecom.Backend.Models;

namespace Ecom.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductRepository _productRepo;
		public ProductsController(IProductRepository productRepo)
		{
			_productRepo = productRepo;
		}

		[HttpGet]
		public ActionResult<List<ProductVm>> GetListProduct(int categoryId = 0)
		{
			List<Product> listProduct;
			if (categoryId > 0)
			{
				listProduct = _productRepo.GetByCategory(categoryId);
			}
			else
			{
				listProduct = _productRepo.GetListProduct();
			}
			var listProductVm = new List<ProductVm>();
			foreach (var item in listProduct)
			{
				var productVm = new ProductVm() 
				{ 
					ProductID = item.ProductID, 
					ProductName = item.ProductName, 
					Image = item.Image, 
					Price = item.Price 
				};
				listProductVm.Add(productVm);
			}
			return Ok(listProductVm);
		}
		

		[HttpGet("{id}")]
		public ActionResult<ProductDetailVm> GetById(int id)
		{
			var product = _productRepo.GetById(id);
			if (product == null)
			{
				return NotFound();
			}
			var productVm = new ProductDetailVm()
			{
				ProductID = product.ProductID,
				ProductName = product.ProductName,
				Image = product.Image,
				Price = product.Price,
				CategoryID = product.CategoryID,
				CategoryName = product.Category.CategoryName,
				ProductDescription = product.ProductDescription,
				RateStar = product.RateStar

			};
			return Ok(productVm);
		}


		[HttpPost]
		public ActionResult<ProductDetailVm> Create(ProductDetailVm productDetailVm)
		{
			var product = new Product()
			{
				ProductName = productDetailVm.ProductName,
				Image = productDetailVm.Image,
				Price = productDetailVm.Price,
				ProductDescription = productDetailVm.ProductDescription,
				CategoryID = productDetailVm.CategoryID,
				CreateDate = DateTime.Now
			};
			var result = _productRepo.Create(product);
			if(result != null)
			{
				return Created("api/products", result.ProductID);
			}
			else
			{
				return Problem("Can't create product");
			}	
		}
		[HttpPut("{id}")]
		public ActionResult<ProductDetailVm> Update(ProductDetailVm productDetailVm, int id)
		{
			if (id != productDetailVm.ProductID)
			{
				return BadRequest("Parameter was invalid");
			}
			var productExist = _productRepo.GetById(id);
			if (productExist == null)
			{
				return NotFound();
			}
			productExist.ProductName = productDetailVm.ProductName;
			productExist.Image = productDetailVm.Image;
			productExist.Price = productDetailVm.Price;
			productExist.ProductDescription = productDetailVm.ProductDescription;
			productExist.CategoryID = productDetailVm.CategoryID;
			productExist.UpdateDate = DateTime.Now;
			var result = _productRepo.Update(productExist);
			if (result != null)
			{
				return NoContent();
			}
			else
			{
				return Problem("Can't create product");
			}
		}


		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var productExist = _productRepo.GetById(id);
			if (productExist != null)
			{
				var result = _productRepo.Delete(productExist);
				if (result)
				{
					return Ok();
				}
				else
				{
					return Problem("Can't delete product");
				}
			}
			else
			{
				return NotFound();		
			}
		}

		[HttpGet("feature/{number}")]
		public ActionResult<List<ProductVm>> GetFeatureProducts(int number)
		{
			if (number <= 0)
			{
				return BadRequest();
			}
			List<Product> listProduct = _productRepo.GetFeatureProducts(number);
			var listProductVm = new List<ProductVm>();
			foreach (var item in listProduct)
			{
				var productVm = new ProductVm()
				{
					ProductID = item.ProductID,
					ProductName = item.ProductName,
					Image = item.Image,
					Price = item.Price
				};
				listProductVm.Add(productVm);
			}
			return Ok(listProductVm);
		}

	}
}
