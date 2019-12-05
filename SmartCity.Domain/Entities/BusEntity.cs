using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCity.Domain.Entities
{
    public class BusEntity : BaseEntity
    {
        public BusEntity() : base() {}

        [BsonElement("Coordinates")]
        [BsonRequired]
        public CoordinatesEntity Coordinates { get; set; }

        [BsonElement("BusRoute")]
        [BsonRequired]
        public BusRouteEntity BusRoute { get; set; }

        [BsonElement("GoingToGarage")]
        [BsonRequired]
        public bool GoingToGarage { get; set; }

        [BsonElement("City")]
        [BsonRequired]
        public CityEntity City { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
