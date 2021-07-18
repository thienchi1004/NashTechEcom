using AutoMapper;
using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Mappings
{
	public class RatingMapper : Profile
	{
		public RatingMapper()
		{
			CreateMap<RatingVm, Rating>().ReverseMap();

			CreateMap<RatingDetailVm, Rating>().ReverseMap();
		}
	}
}
