using Ecom.Backend.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Services
{
	public static class RepositoryService
	{
		public static IServiceCollection AddRepository(this IServiceCollection services)
		{
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IRatingRepository, RatingRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			return services;
		}
	}
}
