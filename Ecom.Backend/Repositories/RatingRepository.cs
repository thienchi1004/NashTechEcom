using Ecom.Backend.Data;
using Ecom.Backend.Models;
using Ecom.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly ApplicationDbContext _context;
		public RatingRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		

		public async Task<Rating> Create(Rating newRating)
		{
			 _context.Ratings.Add(newRating);
			await _context.SaveChangesAsync();

			var sumRating = _context.Ratings.Where(x => x.ProductID.Equals(newRating.ProductID)).Average(x => x.Value);

			var product = await _context.Products.FindAsync(newRating.ProductID);
			product.RateStar = Convert.ToInt32(sumRating);
			await _context.SaveChangesAsync();

			return newRating;
	
		}	

		public async Task<IEnumerable<Rating>> GetRatingsByProductId(int id)
		{
			var ratings = await _context.Ratings
				.Include(p => p.Product)
				.Where(p => p.ProductID.Equals(id))
				.AsNoTracking()
				.ToListAsync();

			var result = await _context.Ratings.AsNoTracking().ToListAsync();

			return result;


		}

		
	}
}
