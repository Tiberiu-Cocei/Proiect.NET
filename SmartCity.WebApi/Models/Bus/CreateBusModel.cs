using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.Models.City;

namespace SmartCity.WebApi.Models.Bus
{
    public class CreateBusModel
    {
        public BusRouteModel BusRoute { get; set; }

        public CityModel City { get; set; }
    }
}
