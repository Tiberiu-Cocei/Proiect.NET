using AutoMapper;
using SmartCity.Domain.Entities;
using SmartCity.WebApi.Models.Coordinates;

namespace SmartCity.WebApi.Mappers
{
    public class CoordinatesMapperProfiler : Profile
    {
        public CoordinatesMapperProfiler()
        {
            CreateMap<CoordinatesModel, CoordinatesEntity>()
                .ForMember(dest => dest.Longitude, map => map.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude, map => map.MapFrom(src => src.Latitude))
                .ForAllOtherMembers(x => x.Ignore());

            CreateMap<CoordinatesEntity, CoordinatesModel>()
                .ForMember(dest => dest.Longitude, map => map.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.Latitude, map => map.MapFrom(src => src.Latitude))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
