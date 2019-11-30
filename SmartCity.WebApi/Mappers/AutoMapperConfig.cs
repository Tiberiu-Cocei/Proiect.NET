using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.Mappers
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Reset();
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PersonMapperProfiler>();
                cfg.AddProfile<PointOfInterestMapperProfiler>();
            });
        }
    }
}
