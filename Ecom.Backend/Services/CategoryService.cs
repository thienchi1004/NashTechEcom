using AutoMapper;
using Ecom.Backend.Models;
using Ecom.Backend.Repositories;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Services
{ 
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IMapper _mapper;
		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepository = categoryRepository;
			_mapper = mapper;
		}

		public Category Create(CategoryCreateVm newCategory)
		{
			var category = _mapper.Map<Category>(newCategory);

			var result = _categoryRepository.Create(category);

			if (result == null)
			{
				return null;
			}
			return result;
		}

		public bool Delete(int id)
		{
			var result = _categoryRepository.Delete(id);

			return result;
		}

		public CategoryVm GetById(int id)
		{
			var cate = _categoryRepository.GetById(id);

			if (cate == null)
			{
				return null;
			}

			var cateVm = _mapper.Map<CategoryVm>(cate);

			return cateVm;
		}

		public List<CategoryVm> GetListCategory()
		{
			var cate = _categoryRepository.GetListCategory();

			if (cate == null)
			{
				return null;
			}

			var result = _mapper.Map<List<CategoryVm>>(cate);
			return result;
			
		}


		public Category Update(CategoryVm categoryUp, int id)
		{
			var categoryExist = _categoryRepository.GetById(id);
			if (categoryExist == null)
			{
				throw new Exception("Category not exist with " + categoryExist.CategoryID);
			}

			var category = _mapper.Map<Category>(categoryUp);
			category.CategoryID = id;
			var result = _categoryRepository.Update(category);
			return result;
		}
	}
}
