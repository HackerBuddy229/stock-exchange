using MediatR;
using StockExchange.Host.mediatr.responses;

namespace StockExchange.Host.mediatr.requests
{
    public class CreateTokenRequest : IRequest<CreateTokenResponse>
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public bool CreateRefreshToken { get; set; }
    }
}