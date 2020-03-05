using FluentValidation;
using SmartCity.WebApi.Models.Coordinates;

namespace SmartCity.WebApi.ModelValidators.Coordinates
{
    public class CoordinatesModelValidator : AbstractValidator<CoordinatesModel>
    {
        public CoordinatesModelValidator()
        {
            RuleFor(x => x.Longitude).NotEmpty().GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
            RuleFor(x => x.Latitude).NotEmpty().GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
        }
    }
}
