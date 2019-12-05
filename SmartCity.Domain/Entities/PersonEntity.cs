using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.Entities
{
    public class PersonEntity : BaseEntity
    {
        public PersonEntity() : base() {}
        
        [BsonElement("FirstName")]
        [BsonRequired]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        [BsonRequired]
        public string LastName { get; set; }

        [BsonElement("Email")]
        [BsonRequired]
        public string Email { get; set; }

        [BsonElement("Coordinates")]
        [BsonRequired]
        public CoordinatesEntity Coordinates { get; set; }

        [BsonElement("PointOfInterestEntities")]
        [BsonRequired]
        public ICollection<PointOfInterestEntity> PointOfInterestEntities { get; set; }

        [BsonElement("Username")]
        [BsonRequired]
        public string Username { get; set; }

        [BsonElement("Password")]
        [BsonRequired]
        public string Password { get; set; }

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate { get; set; }

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate { get; set; }
    }
}
