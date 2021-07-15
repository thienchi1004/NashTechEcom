using Ecom.Backend.Data;
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
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryRepository _cateRepo;
		public CategoryController(ICategoryRepository cateRepo)
		{
			_cateRepo = cateRepo;
		}

		[HttpGet("{id}")]
		public ActionResult<CategoryVm> GetById(int id)
		{
			var category = _cateRepo.GetById(id);
			if (category == null)
			{
				return NotFound();
			}
			var categoryVm = new CategoryVm()
			{
				CategoryID = category.CategoryID,
				CategoryName=category.CategoryName
			};
			return Ok(categoryVm);
		}

		[HttpGet("GetListCategory")]
		public ActionResult<CategoryVm> GetListCategory()
		{
			List<Category> listCategory = _cateRepo.GetListCategory();
			
			var listCategoryVm = new List<CategoryVm>();
			foreach (var item in listCategory)
			{
				var categoryVm = new CategoryVm()
				{
					CategoryID = item.CategoryID,
					CategoryName = item.CategoryName		
				};
				listCategoryVm.Add(categoryVm);
			}
			return Ok(listCategoryVm);
		}


		[HttpPost]
		public ActionResult<CategoryVm> Create(CategoryVm categoryVm)
		{
			var category = new Category()
			{
				CategoryID = categoryVm.CategoryID,
				CategoryName = categoryVm.CategoryName
			};
			var result = _cateRepo.Create(category);
			if (result != null)
			{
				return Created("api/category", result.CategoryID);
			}
			else
			{
				return Problem("Can't create category");
			}
		}





		[HttpPut("{id}")]
		public ActionResult<CategoryVm> Update(CategoryVm categoryVm, int id)
		{
			if(id != categoryVm.CategoryID)
			{
				return BadRequest("Parameter was invalid");
			}
			var categorytExist = _cateRepo.GetById(id);
			if (categorytExist == null)
			{
				return NotFound();
			}
			categorytExist.CategoryID = categoryVm.CategoryID;
			categorytExist.CategoryName = categoryVm.CategoryName;
			
			var result = _cateRepo.Update(categorytExist);
			if (result != null)
			{
				return NoContent();
			}
			else
			{
				return Problem("Can't create category");
			}
		}


		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var categoryExist = _cateRepo.GetById(id);
			if (categoryExist != null)
			{
				var result = _cateRepo.Delete(categoryExist);
				if (result)
				{
					return Ok();
				}
				else
				{
					return Problem("Can't delete category");
				}
			}
			else
			{
				return NotFound();
			}
		}

	}
}
