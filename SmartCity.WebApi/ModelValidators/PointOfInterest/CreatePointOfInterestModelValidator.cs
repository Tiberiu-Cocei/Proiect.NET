using FluentValidation;
using SmartCity.WebApi.Models.PointOfInterest;

namespace SmartCity.WebApi.ModelValidators.PointOfInterest
{
    public class CreatePointOfInterestModelValidator : AbstractValidator<CreatePointOfInterestModel>
    {
        public CreatePointOfInterestModelValidator()
        {
            RuleFor(x => x.Coordinates.Longitude).NotEmpty().GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
            RuleFor(x => x.Coordinates.Latitude).NotEmpty().GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
            RuleFor(x => x.Name).NotEmpty().Length(1, 100);
            RuleFor(x => x.Description).Length(0, 300);
            RuleFor(x => x.IsPrivate).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
        }
    }
}
