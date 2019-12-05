using SmartCity.WebApi.Models.Coordinates;
using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.Models.City;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusStation
{
    public class BusStationModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CoordinatesModel Coordinates { get; set; }
        
        public List<BusRouteModel> BusRoutes { get; set; }

        public CityModel City { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
