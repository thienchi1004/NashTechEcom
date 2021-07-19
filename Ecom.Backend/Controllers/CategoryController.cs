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
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
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
		public ActionResult<Category> Update(CategoryVm categoryUp, int id)
		{
			_categoryService.Update(categoryUp, id);
			return NoContent();
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
