using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Users.Commands.UpdateUser;

namespace Backend.WebAPI.Models.UpdateDto
{
    public class UpdateUserDto 
        : IMapWith<UpdateUserCommand>
    {
        public string? Email { get; set; }
        //public string? Password { get; set; }
        public string? UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string ImgUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(userVm => userVm.UserName,
                    opt => opt.MapFrom(user => user.UserName))
                .ForMember(userVm => userVm.FirstName,
                    opt => opt.MapFrom(user => user.FirstName))
                .ForMember(userVm => userVm.LastName,
                    opt => opt.MapFrom(user => user.LastName))
                .ForMember(userVm => userVm.Patronymic,
                    opt => opt.MapFrom(user => user.Patronymic))
                /*.ForMember(userVm => userVm.Password,
                    opt => opt.MapFrom(user => user.Password))*/
                .ForMember(userVm => userVm.Email,
                    opt => opt.MapFrom(user => user.Email))
                .ForMember(userVm => userVm.ImgUrl,
                    opt => opt.MapFrom(user => user.ImgUrl));
        }
    }
}
