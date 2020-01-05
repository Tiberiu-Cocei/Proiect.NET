using FluentValidation;
using SmartCity.WebApi.Models.PointOfInterest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCity.WebApi.ModelValidators.PointOfInterest
{
    public class GetPointOfInterestModelValidator : AbstractValidator<GetPointOfInterestModel>
    {
        public GetPointOfInterestModelValidator()
        {
            RuleFor(x => x.PersonId).NotNull();
            RuleFor(x => x.CityName).NotNull().NotEmpty();
        }
    }
}
