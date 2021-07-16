using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Ecom.CustomerSite.Services.CategoryClient
{
	public class CategoryApiClient : ICategoryApiClient
	{
		private readonly HttpClient _client;

		public CategoryApiClient(IHttpClientFactory factory)
		{
			_client = factory.CreateClient("host");
		}
		public async Task<List<CategoryVm>> GetListCategory()
		{
			var response = await _client.GetAsync("api/category");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadFromJsonAsync<List<CategoryVm>>();
		}
	}
}
