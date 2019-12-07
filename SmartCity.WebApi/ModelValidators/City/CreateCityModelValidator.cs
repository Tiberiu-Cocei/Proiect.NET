using FluentValidation;
using SmartCity.WebApi.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.ModelValidators.City
{
    public class CreateCityModelValidator : AbstractValidator<CreateCityModel>
    {
        public CreateCityModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(3, 50);
        }
    }
}
