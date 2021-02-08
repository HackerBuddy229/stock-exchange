using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StockExchange.Host.data;
using StockExchange.Host.indentity;

namespace StockExchange.Host.services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationIdentityUser> _userManager;

        public UserService(ApplicationDbContext dbContext, UserManager<ApplicationIdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<ApplicationIdentityUser> GetUser(string id) =>
            await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);


        public async Task<ApplicationIdentityUser> GetUserByEmail(string email) =>
            await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);


        public async Task<bool> CreateUser(ApplicationIdentityUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }

        public async Task DeleteUser(ApplicationIdentityUser user)
        {
            await _userManager.DeleteAsync(user);
        }
    }
}