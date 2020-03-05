using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.Factories
{
    public class CoordinatesFactory
    {
        private double Longitude;

        private double Latitude;

        public CoordinatesFactory() { }

        public CoordinatesEntity GetCoordinatesEntity(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;

            return new CoordinatesEntity
            {
                Longitude = Longitude,
                Latitude = Latitude
            };
        }
    }
}
