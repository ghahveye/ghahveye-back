using Application.DataTransferObjects.User;
using Domain.Entities;

namespace Ghahveye_Back.Profiles
{
    public class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile()
        {
            CreateMap<ApplicationUser, UserForShowDto>();
            CreateMap<Profile, UserForUpdateDto>();
            CreateMap<UserForUpdateDto, Profile>();
            CreateMap<UserForShowDto, ApplicationUser>();
            CreateMap<Profile, UserForShowDto>();
            CreateMap<UserForShowDto, Profile>();


        }
    }
}
