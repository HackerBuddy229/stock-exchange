using AutoMapper;
using StockExchange.Host.DTORequests;
using StockExchange.Host.mediatr.requests;

namespace StockExchange.Host.Profiles
{
    public class DtoCreateUserRequestProfile : Profile
    {
        public DtoCreateUserRequestProfile()
        {
            CreateMap<DtoCreateUserRequest, CreateUserRequest>();
        }
    }
}