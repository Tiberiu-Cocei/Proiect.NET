using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using SmartCity.WebApi.Models.PointOfInterest;
using SmartCity.WebApi.ModelValidators.PointOfInterest;

namespace SmartCity.WebApi.ModelValidator.Person
{
    public class UpdatePersonModelValidator : AbstractValidator<UpdatePersonModel>
    {
        public UpdatePersonModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty().Length(3, 50);
            RuleFor(x => x.LastName).NotEmpty().Length(3, 50);
            RuleFor(x => x.Coordinates.Longitude).NotEmpty().GreaterThanOrEqualTo(-180).LessThanOrEqualTo(180);
            RuleFor(x => x.Coordinates.Latitude).NotEmpty().GreaterThanOrEqualTo(-90).LessThanOrEqualTo(90);
            RuleForEach(x => x.PointOfInterestModels).SetValidator(new CreatePointOfInterestModelValidator());
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
