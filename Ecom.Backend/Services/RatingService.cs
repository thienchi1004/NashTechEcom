using AutoMapper;
using Ecom.Backend.Models;
using Ecom.Backend.Repositories;
using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Services
{
	public class RatingService : IRatingService
	{
		private readonly IRatingRepository _ratingRepository;
		private readonly IMapper _mapper;
		public RatingService(IRatingRepository ratingRepository, IMapper mapper)
		{
			_ratingRepository = ratingRepository;
			_mapper = mapper;
		}
		public RatingVm Create(RatingVm newRating)
		{
			var rating = _mapper.Map<Rating>(newRating);
			rating.DateRating = DateTime.Now;
			var result = _ratingRepository.Create(rating);

			if (result == null)
			{
				return null;
			}

			return _mapper.Map<RatingVm>(result);
		}


		public List<RatingVm> GetRatingsByProductId(int id)
		{
			var result = _ratingRepository.GetRatingsByProductId(id);
			return _mapper.Map<List<RatingVm>>(result);
		}
	}
}
