using System.Threading.Tasks;

namespace StockExchange.Host.services
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateByEmail(string email, string password);
    }
}