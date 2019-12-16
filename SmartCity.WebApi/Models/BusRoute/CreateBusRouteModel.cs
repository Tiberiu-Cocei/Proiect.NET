using SmartCity.WebApi.Models.BusStation;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.BusRoute
{
    public class CreateBusRouteModel
    {
        public string Name { get; set; }

        public ICollection<BusStationModel> BusStations { get; set; }
    }
}
