using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Models;

namespace Backend.Application.Models.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public string UserId { get; set; }
        public string? Email { get; set; }
        //public string? Password { get; set; }
        public string? Name { get; set; }
        public string ImgUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(businessman => businessman.UserId,
                    opt => opt.MapFrom(businessman => businessman.Id))
                .ForMember(businessman => businessman.Email,
                    opt => opt.MapFrom(businessman => businessman.Email))
                //.ForMember(businessman => businessman.Password,
                //    opt => opt.MapFrom(businessman => businessman.Password))
                .ForMember(businessman => businessman.Name,
                    opt => opt.MapFrom(businessman => businessman.UserName))
                .ForMember(clientVm => clientVm.ImgUrl,
                    opt => opt.MapFrom(client => client.ImgUrl));
        }
    }
}
