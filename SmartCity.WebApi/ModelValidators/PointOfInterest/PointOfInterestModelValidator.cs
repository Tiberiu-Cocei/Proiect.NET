using FluentValidation;
using SmartCity.WebApi.Models.PointOfInterest;
using SmartCity.WebApi.Models.Coordinates;

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
            RuleFor(x => x.IsPrivate).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.CreationDate).NotEmpty();
            RuleFor(x => x.ModifiedDate).NotEmpty();
        }
    }
}
