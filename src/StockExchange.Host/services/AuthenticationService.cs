using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockExchange.Host.data;
using StockExchange.Host.indentity;

namespace StockExchange.Host.services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public AuthenticationService(UserManager<ApplicationIdentityUser> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        
        public async Task<bool> AuthenticateByEmail(string email, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return false;

            var result = await _userManager.CheckPasswordAsync(user, password);
            return result;
        }
    }
}