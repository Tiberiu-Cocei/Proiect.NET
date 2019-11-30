using MongoDB.Bson.Serialization.Attributes;

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
