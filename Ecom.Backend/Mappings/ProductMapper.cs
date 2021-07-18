using AutoMapper;
using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Mappings
{
	public class ProductMapper : Profile
	{
		public ProductMapper()
		{
			CreateMap<Product, ProductVm>().ForMember(dest => dest.CategoryName, opt => opt
															 .MapFrom(s => s.Category.CategoryName));

			CreateMap<Product, ProductVm>().ReverseMap();

			CreateMap<ProductDetailVm, Product>()
				.ForPath(x => x.Category.CategoryName, y => y.MapFrom(z => z.CategoryName)).ReverseMap();

			CreateMap<Product, ProductCreateVm>().ReverseMap();
			CreateMap<Product, ProductUpdateVm>().ReverseMap();
		}
	}
}
