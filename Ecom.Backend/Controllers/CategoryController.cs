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
using Ecom.Backend.Services;

namespace Ecom.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryRepository _cateRepo;
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryRepository cateRepo, ICategoryService categoryService)
		{
			_cateRepo = cateRepo;
			_categoryService = categoryService;
		}

		[HttpGet("{id}")]
		public ActionResult<CategoryVm> GetById(int id)
		{
			var category = _categoryService.GetById(id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpGet]
		public ActionResult<CategoryVm> GetListCategory()
		{
			List<CategoryVm> listCategory = _categoryService.GetListCategory();
			return Ok(listCategory);
		}


		[HttpPost]
		public ActionResult<Category> Create(CategoryCreateVm newCategory)
		{
			var result = _categoryService.Create(newCategory);
			if (result == null)
			{
				return BadRequest();
			}
			return result;
		}





		[HttpPut("{id}")]
		public ActionResult<CategoryVm> Update(CategoryVm categoryVm, int id)
		{
			if (id != categoryVm.CategoryID)
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
			var result = _categoryService.Delete(id);
			if (result == true)
			{
				return Ok();
			}
			else
			{
				return Problem("Can't delete category");
			}
		}
	}
}
