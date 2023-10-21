﻿using AutoMapper;
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

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(clientVm => clientVm.UserId,
                    opt => opt.MapFrom(client => client.UserId))
                .ForMember(clientVm => clientVm.Name,
                    opt => opt.MapFrom(client => client.Name))
                .ForMember(clientVm => clientVm.Password,
                    opt => opt.MapFrom(client => client.Password))
                .ForMember(clientVm => clientVm.Email,
                    opt => opt.MapFrom(client => client.Email));
        }
    }
}
