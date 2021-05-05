using AutoMapper;
using JewelleryStore.Domain;
using JewelleryStore.DbModel;
using JewelleryStore.Model;

namespace Jewellery.DataAccess
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<UserMessage, UserProfile>().ReverseMap();
            CreateMap<UserMessage, User>().ReverseMap();
            CreateMap<User, UserProfile>().ReverseMap();
        }
    }
}
