using SmartCity.WebApi.Models.Coordinates;

namespace SmartCity.WebApi.Models.BusStation
{
    public class CreateBusStationModel
    {
        public string Name { get; set; }

        public CoordinatesModel Coordinates { get; set; }
    }
}
