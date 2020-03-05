using AutoMapper;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.PointOfInterest;
using System;

namespace SmartCity.WebApi.Mappers
{
    public class PointOfInterestMapperProfiler : Profile
    {
        public PointOfInterestMapperProfiler()
        {
            CreateMap<PointOfInterestEntity, PointOfInterestModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.PersonId, map => map.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.CityName, map => map.MapFrom(src => src.CityName))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(src => src.ModifiedDate))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreatePointOfInterestModel, PointOfInterestEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.PersonId, map => map.MapFrom(src => src.PersonId))
                .ForMember(dest => dest.CityName, map => map.MapFrom(src => src.CityName))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UpdatePointOfInterestModel, PointOfInterestEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
