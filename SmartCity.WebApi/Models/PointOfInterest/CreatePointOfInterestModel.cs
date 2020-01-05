using SmartCity.WebApi.Models.Coordinates;
using System;

namespace SmartCity.WebApi.Models.PointOfInterest
{
    public class CreatePointOfInterestModel
    {
        public CoordinatesModel Coordinates { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid PersonId { get; set; }

        public string CityName { get; set; }
    }
}
