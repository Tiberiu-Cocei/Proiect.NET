using MongoDB.Bson.Serialization.Attributes;
using System;

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

        public CoordinatesEntity() {}
       
        public CoordinatesEntity(double Longitude, double Latitude)
        {
            this.Longitude = Longitude;
            this.Latitude = Latitude;
        }

        public override bool Equals(Object obj)
        {
            if (obj is CoordinatesEntity)
            {
                var that = obj as CoordinatesEntity;
                return this.Latitude == that.Latitude && this.Longitude == that.Longitude;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Latitude) + Convert.ToInt32(Longitude);
        }
    }
}
