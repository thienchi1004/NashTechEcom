using Ecom.CustomerSite.Services.CategoryClient;
using Ecom.CustomerSite.Services.ProductClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Ecom.CustomerSite
{
	public class Startup
	{
		public static string ServerUrl;
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			ServerUrl = Configuration["ServerUrl"];
			services.AddControllersWithViews();

			// Xac thuc Backend
			services.AddAuthentication(options =>
			{
				options.DefaultScheme = "Cookies";
				options.DefaultChallengeScheme = "oidc";
			})
				 .AddCookie("Cookies")
				 .AddOpenIdConnect("oidc", options =>
				 {
					 options.Authority = Startup.ServerUrl;
					 //  options.RequireHttpsMetadata = false;
					 options.GetClaimsFromUserInfoEndpoint = true;

					 options.ClientId = "mvc";
					 options.ClientSecret = "secret";
					 options.ResponseType = "code";

					 options.SaveTokens = true;

					 options.Scope.Add("openid");
					 options.Scope.Add("profile");
					 options.Scope.Add("assignmentecommerce.api");

					 options.TokenValidationParameters = new TokenValidationParameters
					 {
						 NameClaimType = "name",
						 RoleClaimType = "role"
					 };
				 });

			// 
			services.AddHttpContextAccessor();

			services.AddHttpClient("host", (configureClient) =>
			{
				configureClient.BaseAddress = new Uri(Startup.ServerUrl);
			})
			.ConfigurePrimaryHttpMessageHandler(serProvider =>
			{
				var clientHandler = new HttpClientHandler
				{
					ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true,
				};
				return clientHandler;
			})
				.ConfigureHttpClient(async (serProvider, httpClient) =>
				{
					var httpContext = serProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
					var accessToken = await httpContext.GetTokenAsync("access_token");
					if (accessToken != null)
						httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
				});

			services.AddScoped<ICategoryApiClient, CategoryApiClient>();
			services.AddScoped<IProductApiClient, ProductApiClient>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
