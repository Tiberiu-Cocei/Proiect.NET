using System;

namespace SmartCity.WebApi.Models.Person
{
    public class UpdatePersonModel : CreatePersonModel
    {
        public Guid Id { get; set; }
    }
}
