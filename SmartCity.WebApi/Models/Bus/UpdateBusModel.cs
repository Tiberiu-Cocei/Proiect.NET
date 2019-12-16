using SmartCity.WebApi.Models.Coordinates;
using System;

namespace SmartCity.WebApi.Models.Bus
{
    public class UpdateBusModel
    {
        public Guid Id { get; set; }

        public CoordinatesModel Coordinates { get; set; }

        public bool GoingToGarage { get; set; }
    }
}
