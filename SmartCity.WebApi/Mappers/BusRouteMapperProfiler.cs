using System;
using System.Collections.Generic;
using AutoMapper;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.BusRoute;

namespace SmartCity.WebApi.Mappers
{
    public class BusRouteMapperProfiler : Profile
    {
        public BusRouteMapperProfiler()
        {
            CreateMap<BusRouteEntity, BusRouteModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.BusStations, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.BusStations)))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(src => src.ModifiedDate))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreateBusRouteModel, BusRouteEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.BusStations, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.BusStations)))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UpdateBusRouteModel, BusRouteEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.BusStations, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.BusStations)))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
