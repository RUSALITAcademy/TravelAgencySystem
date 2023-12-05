using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.InternationalPassport.Commands.UpdateInternationalPassport;
using Backend.Application.Models.Orders.Commands.UpdateOrder;
using Backend.Application.Models.Tours.Commands.UpdateTour;

namespace Backend.WebAPI.Models.UpdateDto
{
    public class UpdateInternationalPassportDto : IMapWith<UpdateInternationalPassportCommand>
    {
        public string Series { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateInternationalPassportDto, UpdateInternationalPassportCommand>()
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
