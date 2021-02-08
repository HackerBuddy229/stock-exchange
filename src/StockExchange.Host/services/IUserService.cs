using System.Threading.Tasks;
using StockExchange.Host.indentity;

namespace StockExchange.Host.services
{
    public interface IUserService
    {
        Task<ApplicationIdentityUser> GetUser(string id);
        Task<ApplicationIdentityUser> GetUserByEmail(string email);
        Task<bool> CreateUser(ApplicationIdentityUser user, string password);
        Task DeleteUser(ApplicationIdentityUser user);
    }
}