using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCity.Domain.Entities
{
    public class PersonEntity : BaseEntity
    {
        public PersonEntity() : base()
        {

        }
        
        [BsonElement("FirstName")]
        [BsonRequired]
        public string FirstName;

        [BsonElement("LastName")]
        [BsonRequired]
        public string LastName;

        /*[BsonElement("coor")]
        [BsonRequired]
        public CoordinatesEntity coordinates;*/

        [BsonElement("PointOfInterestEntities")]
        [BsonRequired]
        public ICollection<PointOfInteresEntity> pointOfInteresEntities;

        [BsonElement("Username")]
        [BsonRequired]
        public string Username;

        [BsonElement("Password")]
        [BsonRequired]
        public string Password;

        [BsonElement("CreationDate")]
        [BsonRequired]
        public DateTime CreationDate;

        [BsonElement("ModifiedDate")]
        [BsonRequired]
        public DateTime ModifiedDate;
    }
}
