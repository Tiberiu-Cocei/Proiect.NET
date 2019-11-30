using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.Models.City
{
    public class UpdateCityModel : CreateCityModel
    {
        public Guid Id { get; set; }
    }
}
