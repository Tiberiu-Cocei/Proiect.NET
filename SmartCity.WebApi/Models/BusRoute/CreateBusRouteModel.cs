using SmartCity.WebApi.Models.BusStation;
using SmartCity.WebApi.Models.City;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusRoute
{
    public class CreateBusRouteModel
    {
        public string Name { get; set; }

        public List<BusStationModel> BusStations { get; set; }

        public CityModel City { get; set; }
    }
}
