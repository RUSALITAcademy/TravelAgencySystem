using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Passport.Commands.CreatePassport;
using Backend.Application.Models.Tours.Commands.CreateTour;

namespace Backend.WebAPI.Models.CreateDto
{
    public class CreatePassportDto : IMapWith<CreatePassportCommand>
    {
        public string Series { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Guid UserId { get; set; }
        //public DateTime Birthday { get; set; }
        //public DateTime Issued { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePassportDto, CreatePassportCommand>()
                .ForMember(clientVm => clientVm.Series,
                    opt => opt.MapFrom(client => client.Series))
                .ForMember(clientVm => clientVm.Number,
                    opt => opt.MapFrom(client => client.Number))
                .ForMember(clientVm => clientVm.FirstName,
                    opt => opt.MapFrom(client => client.FirstName))
                .ForMember(clientVm => clientVm.LastName,
                    opt => opt.MapFrom(client => client.LastName))
                .ForMember(clientVm => clientVm.Patronymic,
                    opt => opt.MapFrom(client => client.Patronymic))
                .ForMember(clientVm => clientVm.UserId,
                    opt => opt.MapFrom(client => client.UserId));
        }
    }
}
