using FluentValidation;
using SmartCity.WebApi.Models.PointOfInterest;
using SmartCity.WebApi.ModelValidators.Coordinates;

namespace SmartCity.WebApi.ModelValidators.PointOfInterest
{
    public class PointOfInterestModelValidator : AbstractValidator<PointOfInterestModel>
    {
        public PointOfInterestModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
            RuleFor(x => x.Name).NotEmpty().Length(1, 100);
            RuleFor(x => x.Description).Length(0, 300);
            RuleFor(x => x.CityName).NotEmpty();
            RuleFor(x => x.PersonId).NotNull();
            RuleFor(x => x.CreationDate).NotEmpty();
            RuleFor(x => x.ModifiedDate).NotEmpty();
        }
    }
}
