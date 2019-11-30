using SmartCity.WebApi.Models.Coordinetes;
using SmartCity.WebApi.Models.PointOfInterest;
using System.Collections.Generic;

namespace SmartCity.WebApi.Models.Person
{
    public class CreatePersonModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CoordinatesModel Coordinates { get; set; }

        public List<PointOfInterestModel> PointOfInterestModels { get; set; }

        public string Password { get; set; }
    }
}
