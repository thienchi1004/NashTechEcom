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
		Task<IEnumerable<Rating>> GetRatingsByProductId(int id);
		Task<Rating> Create(Rating newRating);
	}
}
