using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public interface IRatingRepository
	{
		List<Rating> GetRatingsByProductId(int id);
		Rating Create(Rating newRating);
	}
}
