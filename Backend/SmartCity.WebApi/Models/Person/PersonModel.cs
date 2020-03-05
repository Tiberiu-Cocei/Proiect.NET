using SmartCity.WebApi.Models.Coordinates;
using SmartCity.WebApi.Models.PointOfInterest;
using System;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.Person
{
    public class PersonModel
    {
        public Guid Id { get; set; }
         
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public CoordinatesModel Coordinates { get; set; }

        public List<PointOfInterestModel> PointOfInterestModels { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
