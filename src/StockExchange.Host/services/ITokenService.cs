using StockExchange.Host.enums;
using StockExchange.Host.indentity;

namespace StockExchange.Host.services
{
    public interface ITokenService
    {
        string CreateToken(TokenType tokenType, ApplicationIdentityUser user);
    }
}