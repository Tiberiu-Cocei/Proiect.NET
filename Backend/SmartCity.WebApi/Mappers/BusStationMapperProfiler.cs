using AutoMapper;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.BusStation;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Mappers
{
    public class BusStationMapperProfiler : Profile
    {
        public BusStationMapperProfiler()
        {
            CreateMap<BusStationEntity, BusStationModel>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Buses, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.Buses)))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(src => src.CreationDate))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(src => src.ModifiedDate))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CreateBusStationModel, BusStationEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(_ => Guid.NewGuid()))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Buses, map => map.MapFrom(_ => new List<BusEntity>()))
                .ForMember(dest => dest.CreationDate, map => map.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<UpdateBusStationModel, BusStationEntity>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                .ForMember(dest => dest.Coordinates, map => map.MapFrom(src => src.Coordinates))
                .ForMember(dest => dest.Buses, map => map.MapFrom((src, dest, destMember, context) =>
                    context.Mapper.Map<ICollection<PointOfInterestEntity>>(src.Buses)))
                .ForMember(dest => dest.ModifiedDate, map => map.MapFrom(_ => DateTime.Now))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
