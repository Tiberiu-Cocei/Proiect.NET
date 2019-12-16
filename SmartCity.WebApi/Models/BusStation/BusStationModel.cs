using SmartCity.WebApi.Models.Bus;
using SmartCity.WebApi.Models.Coordinates;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusStation
{
    public class BusStationModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public CoordinatesModel Coordinates { get; set; }
        
        public ICollection<BusModel> Buses { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
