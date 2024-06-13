using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Domain.Models;

namespace Backend.Application.Models.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public string UserId { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(clientVm => clientVm.UserId,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(clientVm => clientVm.Email,
                    opt => opt.MapFrom(client => client.Email))
                .ForMember(clientVm => clientVm.FirstName,
                    opt => opt.MapFrom(client => client.FirstName))
                .ForMember(clientVm => clientVm.LastName,
                    opt => opt.MapFrom(client => client.LastName))
                .ForMember(clientVm => clientVm.MiddleName,
                    opt => opt.MapFrom(client => client.MiddleName));
        }
    }
}
