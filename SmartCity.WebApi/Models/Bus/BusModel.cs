using SmartCity.WebApi.Models.Coordinates;
using System;
namespace SmartCity.WebApi.Models.Bus
{
    public class BusModel
    {
        public Guid Id { get; set; }

        public CoordinatesModel Coordinates { get; set; }

        public bool GoingToGarage { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
