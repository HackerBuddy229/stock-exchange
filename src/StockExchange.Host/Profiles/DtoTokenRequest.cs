using AutoMapper;
using StockExchange.Host.mediatr.requests;

namespace StockExchange.Host.Profiles
{
    public class DtoTokenRequest : Profile
    {
        public DtoTokenRequest()
        {
            CreateMap<DtoTokenRequest, CreateTokenRequest>();
        }
    }
}