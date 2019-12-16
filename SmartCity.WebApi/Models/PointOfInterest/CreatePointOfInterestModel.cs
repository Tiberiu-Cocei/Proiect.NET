using System;
using System.Collections.Generic;
using SmartCity.WebApi.Models.City;
using SmartCity.WebApi.Models.Coordinates;

namespace SmartCity.WebApi.Models.PointOfInterest
{
    public class CreatePointOfInterestModel
    {
        public CoordinatesModel Coordinates { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsPrivate { get; set; }
    }
}
