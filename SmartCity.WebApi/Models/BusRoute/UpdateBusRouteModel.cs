using SmartCity.WebApi.Models.BusStation;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusRoute
{
    public class UpdateBusRouteModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<BusStationModel> BusStations { get; set; }
    }
}
