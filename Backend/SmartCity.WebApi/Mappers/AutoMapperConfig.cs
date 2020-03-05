using AutoMapper;

namespace SmartCity.WebApi.Mappers
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<BusMapperProfiler>();
                cfg.AddProfile<BusRouteMapperProfiler>();
                cfg.AddProfile<BusStationMapperProfiler>();
                cfg.AddProfile<CityMapperProfiler>();
                cfg.AddProfile<CoordinatesMapperProfiler>();
                cfg.AddProfile<PersonMapperProfiler>();
                cfg.AddProfile<PointOfInterestMapperProfiler>();
            });
        }
    }
}