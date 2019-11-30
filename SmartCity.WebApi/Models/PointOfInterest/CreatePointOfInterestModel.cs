using SmartCity.WebApi.Models.City;
using SmartCity.WebApi.Models.Coordinates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.Models.PointOfInterest
{
    public class CreatePointOfInterestModel
    {
        public CoordinatesModel Coordinates { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }

        public CityModel City { get; set; }
    }
}
