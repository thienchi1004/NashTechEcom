
using Ecom.Backend.Data;
using Ecom.Backend.IdentityServer;
using Ecom.Backend.IdentitySever;
using Ecom.Backend.Models;
using Ecom.Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Ecom.Backend
{
	public class Startup
	{
		public static Dictionary<string, string> ClientUrls;

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			ClientUrls = new Dictionary<string, string>()
			{
				["react"] = Configuration["ClientUrls:react"],
				["mvc"] = Configuration["ClientUrls:mvc"],
				["backend"] = Configuration["ClientUrls:backend"],
			};
			services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(
				   Configuration.GetConnectionString("DefaultConnection")));
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
			   .AddRoles<IdentityRole>()
			   .AddEntityFrameworkStores<ApplicationDbContext>();
			services.AddMemoryCache();
			services.AddIdentityServer(options =>
			{
				options.Events.RaiseErrorEvents = true;
				options.Events.RaiseInformationEvents = true;
				options.Events.RaiseFailureEvents = true;
				options.Events.RaiseSuccessEvents = true;
				options.EmitStaticAudienceClaim = true;
			}).AddInMemoryIdentityResources(IdentityServerConfig.IdentityResources)
			 .AddInMemoryApiScopes(IdentityServerConfig.ApiScopes)
			 .AddInMemoryClients(IdentityServerConfig.Clients)
			 .AddAspNetIdentity<User>()
			 .AddProfileService<CustomProfileService>()
			 .AddDeveloperSigningCredential();

			//authen
			services
				.AddAuthentication()
				.AddLocalApi("Bearer", options =>
				{
					options.ExpectedScope = "assignmentecommerce.api";
				});

			//author
			services.AddAuthorization(options =>
			{
				options.AddPolicy("Bearer", policy =>
				{
					policy.AddAuthenticationSchemes("Bearer");
					policy.RequireAuthenticatedUser();
				});

			});
			services.AddControllersWithViews()
				.AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
			services.AddRazorPages();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Assignment Ecommerce API", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.OAuth2,
					Flows = new OpenApiOAuthFlows
					{
						AuthorizationCode = new OpenApiOAuthFlow
						{
							TokenUrl = new Uri("/connect/token", UriKind.Relative),
							AuthorizationUrl = new Uri("/connect/authorize", UriKind.Relative),
							Scopes = new Dictionary<string, string> { { "assignmentecommerce.api", "Assignment Ecommerce API" } }
						},
					},
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
						},
						new List<string>{ "assignmentecommerce.api" }
					}
				});
			});

			services.AddRepository();
			services.AddTransient<IProductService, ProductService>();
			services.AddTransient<ICategoryService, CategoryService>();


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
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseRouting();

			app.UseIdentityServer();
			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.OAuthClientId("swagger");
				c.OAuthClientSecret("secret");
				c.OAuthUsePkce();
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Assignment Ecommerce API V1");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapRazorPages();
			});
		}
	}
}
