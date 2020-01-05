using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.Models.PointOfInterest
{
    public class GetPointOfInterestModel
    {
        public Guid PersonId { get; set; }
        public string CityName { get; set; }
    }
}
