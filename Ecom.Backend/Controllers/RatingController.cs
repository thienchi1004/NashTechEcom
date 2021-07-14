using Ecom.Backend.Models;
using Ecom.Backend.Repositories;
using Ecom.Shared.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ecom.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingController : ControllerBase
	{
		private readonly IRatingRepository _ratingRepo;
		public RatingController(IRatingRepository ratingRepo)
		{
			_ratingRepo = ratingRepo;
		}

        [HttpPost]

        public async Task<ActionResult<RatingVm>> CreateRating(RatingVm ratingVm)
        {
            var rating = new Rating()
            {
                Value = ratingVm.Value,
                Comment = ratingVm.Comment,
                ProductID = ratingVm.ProductID,
                DateRating = DateTime.Now
            };
            var result = await _ratingRepo.Create(rating);
            if (result != null)
			{
                return Created("api/rating", result.IdRating);
            }
            return Problem("Can't create rating");
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RatingVm>>> GetRatingsByProductID(int id)
        {
            var result = await _ratingRepo.GetRatingsByProductId(id);
            var listRatingVm = new List<RatingVm>();
            foreach (var item in result)
            {
                var ratingVm = new RatingVm()
                {
                    IdRating = item.IdRating,
                    Comment= item.Comment,
                    ProductID = item.ProductID,
                    DateRating = DateTime.Now,
                    Value = item.Value
                };
                listRatingVm.Add(ratingVm);
            }
            return Ok(listRatingVm);
        }
    }
}
