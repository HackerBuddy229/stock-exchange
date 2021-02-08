using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockExchange.Host.mediatr.requests;
using StockExchange.Host.Profiles;

namespace StockExchange.Host.Controllers
{
    [Route("Authentication/")]
    public class AuthenticationController : Controller
    {
        private readonly Mediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(Mediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("GetBearerToken")]
        public async Task<IActionResult> GetBearerToken([FromBody]DtoTokenRequest request)
        {
            var mediatrRequest = _mapper.Map<CreateTokenRequest>(request);
            var result = await _mediator.Send(mediatrRequest);
            
            
            throw new NotImplementedException();
        }
    }
}