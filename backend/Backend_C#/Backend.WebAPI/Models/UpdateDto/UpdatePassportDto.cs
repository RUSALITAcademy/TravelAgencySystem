using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.InternationalPassport.Commands.UpdateInternationalPassport;
using Backend.Application.Models.Passport.Commands.UpdatePassport;

namespace Backend.WebAPI.Models.UpdateDto
{
    public class UpdatePassportDto : IMapWith<UpdatePassportCommand>
    {
        public int Series { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePassportDto, UpdatePassportCommand>()
                .ForMember(clientVm => clientVm.Series,
                    opt => opt.MapFrom(client => client.Series))
                .ForMember(clientVm => clientVm.Number,
                    opt => opt.MapFrom(client => client.Number))
                .ForMember(clientVm => clientVm.FirstName,
                    opt => opt.MapFrom(client => client.FirstName))
                .ForMember(clientVm => clientVm.LastName,
                    opt => opt.MapFrom(client => client.LastName))
                .ForMember(clientVm => clientVm.Patronymic,
                    opt => opt.MapFrom(client => client.Patronymic));
        }
    }
}
