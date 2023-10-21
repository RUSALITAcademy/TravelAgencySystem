using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Users.Commands.UpdateUser;

namespace Backend.WebAPI.Models.UpdateDto
{
    public class UpdateUserDto 
        : IMapWith<UpdateUserCommand>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(userVm => userVm.Name,
                    opt => opt.MapFrom(user => user.Name))
                .ForMember(userVm => userVm.Password,
                    opt => opt.MapFrom(user => user.Password))
                .ForMember(userVm => userVm.Email,
                    opt => opt.MapFrom(user => user.Email));
        }
    }
}
