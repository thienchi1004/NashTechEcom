using Ecom.Backend.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecom.Backend.Repositories
{
	public class UserRepository : IUserRepository
	{
        private readonly ApplicationDbContext _context;


        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IdentityUser>> GetUser()
        {
            var user = await _context.Users.AsNoTracking().ToListAsync();

            return user;
        }
    }
}
