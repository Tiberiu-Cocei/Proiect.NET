using SmartCity.WebApi.Models.Coordinates;
using System;

namespace SmartCity.WebApi.Models.PointOfInterest
{
    public class UpdatePointOfInterestModel : CreatePointOfInterestModel
    {
        public Guid Id { get; set; }
    }
}
