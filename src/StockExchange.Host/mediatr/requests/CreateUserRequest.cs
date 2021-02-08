using MediatR;
using StockExchange.Host.mediatr.responses;

namespace StockExchange.Host.mediatr.requests
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}