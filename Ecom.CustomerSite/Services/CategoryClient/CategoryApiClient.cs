using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Services.CategoryClient
{
	public class CategoryApiClient : ICategoryApiClient
	{
		private readonly HttpClient _client;

		public CategoryApiClient(HttpClient client)
		{
			_client = client;
		}
		public async Task<List<CategoryVm>> GetListCategory()
		{
			var response = await _client.GetAsync("api/categories");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<List<CategoryVm>>();
		}
	}
}
