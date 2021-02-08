using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StockExchange.Host.enums;
using StockExchange.Host.mediatr.requests;
using StockExchange.Host.mediatr.responses;
using StockExchange.Host.models;
using StockExchange.Host.services;

namespace StockExchange.Host.mediatr.handlers
{
    public class TokenCreationHandler : IRequestHandler<CreateTokenRequest, CreateTokenResponse>
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly ITokenService _tokenService;

        public TokenCreationHandler(IUserService userService, 
            IAuthenticationService authenticationService, 
            ITokenService tokenService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
            _tokenService = tokenService;
        }
        
        
        public async Task<CreateTokenResponse> Handle(CreateTokenRequest request, CancellationToken cancellationToken)
        {
            var authenticationResult =
                await _authenticationService.AuthenticateByEmail(request.Email, request.Password);
            
            if (!authenticationResult)
                return new CreateTokenResponse {Errors = new List<string> {"Invalid authentication"}};

            var user = await _userService.GetUserByEmail(request.Email);
            
            if (user == null)
                return new CreateTokenResponse {Errors = new List<string> {"Invalid user"}};

            var authenticationToken = _tokenService.CreateToken(TokenType.Authentication, user);
            var refreshToken = request.CreateRefreshToken ? _tokenService.CreateToken(TokenType.Refresh, user) : null;

            var tokenFamily = new TokenFamily
            {
                AuthenticationToken = authenticationToken,
                RefreshToken = refreshToken
            };

            return new CreateTokenResponse {WorkProduct = tokenFamily};
        }
    }
}