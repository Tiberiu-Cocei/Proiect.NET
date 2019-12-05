using SmartCity.WebApi.Models.Coordinates;
using SmartCity.WebApi.Models.BusRoute;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusStation
{
    public class UpdateBusStationModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CoordinatesModel Coordinates { get; set; }
        
        public List<BusRouteModel> BusRoutes { get; set; }
    }
}
