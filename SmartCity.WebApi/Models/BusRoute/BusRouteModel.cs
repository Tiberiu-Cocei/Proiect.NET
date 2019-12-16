using SmartCity.WebApi.Models.BusStation;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusRoute
{
    public class BusRouteModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<BusStationModel> BusStations { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}