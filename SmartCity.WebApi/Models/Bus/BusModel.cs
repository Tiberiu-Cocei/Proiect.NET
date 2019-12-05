using SmartCity.WebApi.Models.Coordinates;
using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.Models.City;
using System;
namespace SmartCity.WebApi.Models.Bus
{
    public class BusModel
    {
        public Guid Id { get; set; }

        public CoordinatesModel Coordinates { get; set; }

        public BusRouteModel BusRoute { get; set; }

        public bool GoingToGarage { get; set; }

        public CityModel City { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
