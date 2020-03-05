using SmartCity.WebApi.Models.Coordinates;
using System;

namespace SmartCity.WebApi.Models.PointOfInterest
{
    public class UpdatePointOfInterestModel
    {
        public Guid Id { get; set; }

        public CoordinatesModel Coordinates { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
