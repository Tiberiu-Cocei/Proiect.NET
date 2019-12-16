using AutoMapper;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.City;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Mappers
{
    public class CityMapperProfiler : Profile
    {
        public CityMapperProfiler()
        {
            CreateMap<CityEntity, CityModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.BusRoutes, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.BusRoutes)))
                .ForMember(dest => dest.PointsOfInterests, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.PointsOfInterests)))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(src => src.ModifiedDate))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreateCityModel, CityEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.BusRoutes, map => map.MapFrom(_ => new List<BusRouteEntity>()))
                .ForMember(dest => dest.PointsOfInterests, map => map.MapFrom(_ => new List<PointOfInterestEntity>()))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UpdateCityModel, CityEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.BusRoutes, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.BusRoutes)))
                .ForMember(dest => dest.PointsOfInterests, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.PointsOfInterests)))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
