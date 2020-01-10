using SmartCity.WebApi.Models.Coordinates;

namespace SmartCity.WebApi.Models.Bus
{
    public class CreateBusModel
    {
        public string BusNumber { get; set; }

        public CoordinatesModel Coordinates { get; set; }
    }
}
