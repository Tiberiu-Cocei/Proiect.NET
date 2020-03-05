using FluentValidation;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.ModelValidators.Coordinates;
using SmartCity.WebApi.ModelValidators.PointOfInterest;

namespace SmartCity.WebApi.ModelValidators.Person
{
    public class UpdatePersonModelValidator : AbstractValidator<UpdatePersonModel>
    {
        public UpdatePersonModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().Length(3, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(3, 50);
            RuleFor(x => x.Email).NotEmpty().Length(10, 50);
            RuleFor(x => x.Coordinates).SetValidator(new CoordinatesModelValidator());
            RuleForEach(x => x.PointOfInterestModels).SetValidator(new PointOfInterestModelValidator());
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
