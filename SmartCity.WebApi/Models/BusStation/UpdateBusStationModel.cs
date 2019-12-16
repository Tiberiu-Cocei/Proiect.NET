using SmartCity.WebApi.Models.Coordinates;
using System;
using System.Collections.Generic;
using SmartCity.WebApi.Models.Bus;

namespace SmartCity.WebApi.Models.BusStation
{
    public class UpdateBusStationModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CoordinatesModel Coordinates { get; set; }
        
        public ICollection<BusModel> Buses { get; set; }
    }
}
