using AutoMapper;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.Person;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Mappers
{
    public class PersonMapperProfiler : Profile
    {
        public PersonMapperProfiler()
        {
            CreateMap<PersonEntity, PersonModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.PointOfInterestModels, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.PointOfInterestEntities)))
                .ForMember(dest => dest.Username, map => map.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, map => map.MapFrom(src => src.Password))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(src => src.ModifiedDate))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreatePersonModel, PersonEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(_ => new CoordinatesEntity()))
                .ForMember(dest => dest.PointOfInterestEntities, map => map.MapFrom(_ => new List<PointOfInterestEntity>()))
                .ForMember(dest => dest.Username, map => map.MapFrom(src => src.Username))
                .ForMember(dest => dest.Password, map => map.MapFrom(src => src.Password))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UpdatePersonModel, PersonEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, map => map.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.PointOfInterestEntities, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.PointOfInterestModels)))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, map => map.MapFrom(src => src.Password))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
