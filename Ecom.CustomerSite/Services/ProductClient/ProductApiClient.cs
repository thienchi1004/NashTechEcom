using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Ecom.CustomerSite.Services.ProductClient
{
	public class ProductApiClient : IProductApiClient
	{
		private readonly HttpClient _client;
		private readonly string routerName = "api/products";
		public ProductApiClient(IHttpClientFactory factory)
		{
			_client = factory.CreateClient("host");
		}

		public async Task<ProductDetailVm> GetById(int id)
		{
			var reponse = await _client.GetAsync(routerName+ "/"+ id);
			reponse.EnsureSuccessStatusCode();
			return await reponse.Content.ReadFromJsonAsync<ProductDetailVm>();
		}

		public async Task<List<ProductVm>> GetListProduct()
		{
			var reponse = await _client.GetAsync(routerName);
			reponse.EnsureSuccessStatusCode();
			return await reponse.Content.ReadFromJsonAsync<List<ProductVm>>();
		}

		public async Task<List<ProductVm>> GetByCategory(int id)
		{
			var reponse = await _client.GetAsync(routerName +"?category=" + id);
			reponse.EnsureSuccessStatusCode();
			return await reponse.Content.ReadFromJsonAsync<List<ProductVm>>();
		}

		public async Task<List<ProductVm>> GetFeatureProduct()
		{
			var reponse = await _client.GetAsync(routerName + "/feature/" + 5);
			reponse.EnsureSuccessStatusCode();
			return await reponse.Content.ReadFromJsonAsync<List<ProductVm>>();
		}
	}
}
