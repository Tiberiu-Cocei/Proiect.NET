using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.Models.PointOfInterest;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.City
{
    public class CityModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<BusRouteModel> BusRoutes { get; set; }

        public List<PointOfInterestModel> PointsOfInterests { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
