using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<IdentityUser>> GetUser();
	}
}
