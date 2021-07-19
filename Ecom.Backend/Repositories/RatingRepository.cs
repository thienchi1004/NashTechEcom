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

		

		public Rating Create(Rating newRating)
		{
			var productExist = _context.Products.Find(newRating.ProductID);
			if (productExist == null)
			{
				throw new Exception("Product " + newRating.ProductID + " was not found");
			}
			var userExist = _context.Users.Find(newRating.UserId);
			if (userExist == null)
			{
				throw new Exception("User " + newRating.UserId + " was not found");
			}
			_context.Ratings.Add(newRating);
			_context.SaveChanges();

			var sumRating = _context.Ratings.Where(x => x.ProductID.Equals(newRating.ProductID)).Average(x => x.Value);

			var product = _context.Products.Find(newRating.ProductID);
			product.RateStar = Convert.ToInt32(sumRating);
			_context.SaveChanges();

			return newRating;
	
		}	

		public List<Rating> GetRatingsByProductId(int id)
		{
			var ratings = _context.Ratings
				.Include(p => p.Product).Include(p => p.User)
				.Where(p => p.ProductID.Equals(id))
				.AsNoTracking()
				.ToList();

			return ratings;


		}

		
	}
}
