using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Users.Commands.CreateUser;

namespace Backend.WebAPI.Models.CreateDto
{
    public class CreateUserDto
        : IMapWith<CreateUserCommand>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string ImgUrl { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(userVm => userVm.FirstName,
                    opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userVm => userVm.LastName,
                    opt => opt.MapFrom(user => user.LastName))
                .ForMember(userVm => userVm.MiddleName,
                    opt => opt.MapFrom(user => user.MiddleName))
                .ForMember(userVm => userVm.Password,
                    opt => opt.MapFrom(user => user.Password))
                .ForMember(userVm => userVm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.ImgUrl,
                    opt => opt.MapFrom(user => user.ImgUrl));
        }
    }
}
