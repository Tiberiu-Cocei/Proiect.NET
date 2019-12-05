using SmartCity.WebApi.Models.Coordinates;
using SmartCity.WebApi.Models.City;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusStation
{
    public class CreateBusStationModel
    {
        public string Name { get; set; }

        public CoordinatesModel Coordinates { get; set; }

        public CityModel City { get; set; }
    }
}
