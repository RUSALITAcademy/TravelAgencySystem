using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Models.Passport.Queries.GetPassportDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Models.InternationalPassport.Queries.GetInternationalPassportDetails
{
    public class InternationalPassportDetailsVm : IMapWith<Domain.Models.InternationalPassport>
    {
        public int Series { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Guid UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Models.InternationalPassport, InternationalPassportDetailsVm>()
                .ForMember(clientVm => clientVm.UserId,
                    opt => opt.MapFrom(client => client.UserId))
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
