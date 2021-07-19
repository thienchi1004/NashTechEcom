using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Services
{
	public interface IRatingService
	{
		List<RatingVm> GetRatingsByProductId(int id);
		RatingVm Create(RatingVm newRating);
	}
}
