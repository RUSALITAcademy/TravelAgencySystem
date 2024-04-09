using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Models;

namespace Backend.Application.Models.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string ImgUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(clientVm => clientVm.UserId,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(clientVm => clientVm.Name,
                    opt => opt.MapFrom(client => client.UserName))
                //.ForMember(clientVm => clientVm.Password,
                //    opt => opt.MapFrom(client => client.Password))
                .ForMember(clientVm => clientVm.Email,
                    opt => opt.MapFrom(client => client.Email))
                .ForMember(clientVm => clientVm.ImgUrl,
                    opt => opt.MapFrom(client => client.ImgUrl));
        }
    }
}
