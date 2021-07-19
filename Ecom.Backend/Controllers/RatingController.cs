using Ecom.Backend.Models;
using Ecom.Backend.Repositories;
using Ecom.Backend.Services;
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
        private readonly IRatingService _ratingService;
		public RatingController(IRatingService ratingService )
		{
            _ratingService = ratingService;
		}

        [HttpPost]

        public  ActionResult<RatingVm> CreateRating(RatingVm ratingVm)
        {
            var result = _ratingService.Create(ratingVm);

            if (result == null)
            {
                return BadRequest();
            }

            return result;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RatingVm>> GetRatingsByProductID(int id)
        {
            var result =  _ratingService.GetRatingsByProductId(id);
            return Ok(result);
        }
    }
}
