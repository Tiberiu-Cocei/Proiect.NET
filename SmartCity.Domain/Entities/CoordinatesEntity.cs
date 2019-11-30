using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCity.Domain.Entities
{
    public class CoordinatesEntity
    {
        [BsonElement("Longitude")]
        [BsonRequired]
        public double Longitude;

        [BsonElement("Latitude")]
        [BsonRequired]
        public double Latitude;
    }
}
