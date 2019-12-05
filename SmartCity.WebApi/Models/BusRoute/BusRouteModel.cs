using SmartCity.WebApi.Models.BusStation;
using SmartCity.WebApi.Models.City;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusRoute
{
    public class BusRouteModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<BusStationModel> BusStations { get; set; }

        public CityModel City { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
