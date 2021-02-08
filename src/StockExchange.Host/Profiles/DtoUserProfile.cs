using AutoMapper;
using StockExchange.Host.data.models;
using StockExchange.Host.indentity;

namespace StockExchange.Host.Profiles
{
    public class DtoUserProfile: Profile
    {
        public DtoUserProfile()
        {
            CreateMap<ApplicationIdentityUser, DtoIdentityUser>();
        }
    }
}