using AutoMapper;
using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Mappings
{
	public class CategoryMapper : Profile
	{
		public CategoryMapper()
		{
			CreateMap<CategoryVm, Category>().ReverseMap();

			CreateMap<CategoryCreateVm, Category>().ReverseMap();

		}

	}
}
