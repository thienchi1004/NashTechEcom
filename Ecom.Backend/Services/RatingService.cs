using AutoMapper;
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
		public Task<RatingVm> Create(RatingDetailVm newRating)
		{
			var rating = _mapper.Map<RatingVm>(newRating);

			var result = _ratingRepository.Create(rating);

			if (result == null)
			{
				return null;
			}
			return newRating;
		}

		public Task<IEnumerable<RatingVm>> GetRatingsByProductId(int id)
		{
			throw new NotImplementedException();
		}
	}
}
