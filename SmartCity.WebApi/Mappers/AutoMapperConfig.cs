using AutoMapper;

namespace SmartCity.WebApi.Mappers
{
    public static class AutoMapperConfig
    {
        public static void Initialize() //nu stiu daca merge cum trebuie
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<PersonMapperProfiler>();
                cfg.AddProfile<PointOfInterestMapperProfiler>();
            });
        }
    }
}