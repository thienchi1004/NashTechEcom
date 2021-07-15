using Ecom.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text;
using Newtonsoft.Json;


namespace Ecom.CustomerSite.Services.ProductClient
{
	public class ProductApiClient : IProductApiClient
	{
		private readonly HttpClient _client;
		public ProductApiClient(HttpClient client)
		{
			_client = client;
		}

		public async Task<ProductVm> GetById(int id)
		{
			var reponse = await _client.GetAsync("api/product/getbyid" + id);
			reponse.EnsureSuccessStatusCode();
			return await reponse.Content.ReadAsAsync<ProductVm>();
		}

		public async Task<List<ProductVm>> GetListProduct()
		{
			var reponse = await _client.GetAsync("api/product/getlistproduct");
			reponse.EnsureSuccessStatusCode();
			return await reponse.Content.ReadAsAsync<List<ProductVm>>();
		}

		public async Task<List<ProductVm>> GetByCategory(int id)
		{
			var reponse = await _client.GetAsync("api/product" + id);
			reponse.EnsureSuccessStatusCode();
			return await reponse.Content.ReadAsAsync<List<ProductVm>>();
		}
	}
}
