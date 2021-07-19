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
			CreateMap<RatingVm, Rating>();

			CreateMap<Rating, RatingVm>().ForMember(src => src.UserName, opt => opt.MapFrom(des => des.User.UserName));
		}
	}
}
