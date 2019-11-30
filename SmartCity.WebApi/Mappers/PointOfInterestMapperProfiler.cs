using System;
using AutoMapper;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.PointOfInterest;
using SmartCity.WebApi.Models.Coordinates;

namespace SmartCity.WebApi.Mappers
{
    public class PointOfInterestMapperProfiler : Profile
    {
        public PointOfInterestMapperProfiler()
        {
            CreateMap<CoordinatesModel, CoordinatesEntity>()
                .ForMember(dest => dest.Longitude, map => map.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude, map => map.MapFrom(src => src.Latitude))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CoordinatesEntity, CoordinatesModel>()
                .ForMember(dest => dest.Longitude, map => map.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude, map => map.MapFrom(src => src.Latitude))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<PointOfInterestEntity, PointOfInterestModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsPrivate, map => map.MapFrom(src => src.IsPrivate))
                .ForMember(dest => dest.City, map => map.MapFrom(src => src.City))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(src => src.ModifiedDate))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreatePointOfInterestModel, PointOfInterestEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, map => map.MapFrom(src => src.Description))
                .ForMember(dest => dest.IsPrivate, map => map.MapFrom(src => src.IsPrivate))
                .ForMember(dest => dest.City, map => map.MapFrom(src => src.City))
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
