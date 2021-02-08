using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using StockExchange.Host.data.models;
using StockExchange.Host.indentity;
using StockExchange.Host.mediatr.requests;
using StockExchange.Host.mediatr.responses;
using StockExchange.Host.services;

namespace StockExchange.Host.mediatr.handlers
{
    public class UserCreationHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserCreationHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        
        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = new ApplicationIdentityUser
            {
                Email = request.Email,
                UserName = request.Email
            };
            
            var result = await _userService.CreateUser(user, request.Password);
            
            return result
                ? new CreateUserResponse{WorkProduct = _mapper.Map<DtoIdentityUser>(user)}
                : new CreateUserResponse {Errors = new List<string> {"Not a valid request"}};
        }
    }
}