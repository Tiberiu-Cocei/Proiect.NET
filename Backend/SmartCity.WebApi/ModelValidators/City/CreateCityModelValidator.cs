using FluentValidation;
using SmartCity.WebApi.Models.City;

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
