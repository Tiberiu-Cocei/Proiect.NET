using System;

namespace SmartCity.WebApi.Models.City
{
    public class UpdateCityModel : CreateCityModel
    {
        public Guid Id { get; set; }
    }
}
