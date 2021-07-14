using Ecom.Backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepo;
		public UserController(IUserRepository userRepo)
		{
			_userRepo = userRepo;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<IdentityUser>>> GetUser()
		{
			var user = await _userRepo.GetUser();

			return Ok(user);
		}
	}
}
