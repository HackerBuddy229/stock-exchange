using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockExchange.Host.DTORequests;
using StockExchange.Host.mediatr.requests;

namespace StockExchange.Host.Controllers
{
    [Authorize]
    [Route("Users/")]
    public class UserController : Controller
    {
        private readonly Mediator _mediator;
        private readonly IMapper _mapper;

        public UserController(Mediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        [Route("Create")] [HttpPost] [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody]DtoCreateUserRequest request)
        {
            var result = await _mediator.Send(_mapper.Map<CreateUserRequest>(request));
            if (result != null && result.Succeeded)
                return Ok(result.WorkProduct); //TODO: change to created

            return result switch
            {
                null => BadRequest(),
                _ => BadRequest(result.Errors)
            };
        }


    }
}