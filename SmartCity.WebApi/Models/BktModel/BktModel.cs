using SmartCity.Domain.Entities;

namespace SmartCity.WebApi.Models.BktModel
{
    public class BktModel
    {
        public string RouteNumber { get; set; }
        public string BoardingStation { get; set; }
        public CoordinatesEntity BoardingCoodinates { get; set; }
        public string ExitStation { get; set; }
        public CoordinatesEntity ExitCoordinates { get; set; }
    }
}
