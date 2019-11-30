using FluentValidation;
using SmartCity.WebApi.Models.PointOfInterest;

namespace SmartCity.WebApi.ModelValidator.PointOfInterest
{
    public class UpdatePointOfInterestModelValidator : AbstractValidator<UpdatePointOfInterestModel>
    {
        public UpdatePointOfInterestModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Coordinates.Longitude).NotEmpty().GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
            RuleFor(x => x.Coordinates.Latitude).NotEmpty().GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
            RuleFor(x => x.Name).NotEmpty().Length(1, 100);
            RuleFor(x => x.Description).Length(0, 300);
        }
    }
}
